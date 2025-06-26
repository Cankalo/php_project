<?php
include '../inc/db_connectie.php';

$gebruikersnaam = $_POST['gebruikersnaam'];
$wachtwoord = password_hash($_POST['wachtwoord'], PASSWORD_DEFAULT);

$stmt = $mysqli->prepare("INSERT INTO gebruikers (gebruikersnaam, wachtwoord) VALUES (?, ?)");
$stmt->bind_param("ss", $gebruikersnaam, $wachtwoord);

if ($stmt->execute()) {
   header("Location: ../login.php");
exit();
} else {
    echo "Registratie mislukt. Probeer opnieuw.";
}
?>
