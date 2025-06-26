<?php
session_start();
include '../inc/db_connectie.php';

$gebruikersnaam = $_POST['gebruikersnaam'];
$wachtwoord = $_POST['wachtwoord'];

$stmt = $mysqli->prepare("SELECT * FROM gebruikers WHERE gebruikersnaam = ?");
$stmt->bind_param("s", $gebruikersnaam);
$stmt->execute();
$resultaat = $stmt->get_result();

if ($resultaat->num_rows === 1) {
    $gebruiker = $resultaat->fetch_assoc();
    if (password_verify($wachtwoord, $gebruiker['wachtwoord'])) {
        $_SESSION['gebruiker'] = $gebruiker['gebruikersnaam'];
        // Giriş başarılıysa ana web sayfasına yönlendir:
        header("Location: ../Homepagina/home.html");
        exit;
    }
}
header("Location: ../login.php?fout=1");
exit;
?>