<?php
$host = "localhost";
$gebruikers = "root";
$wachtwoord = "";
$database = "stemwijzerr";

$mysqli = new mysqli($host, $gebruikers, $wachtwoord, $database, 3307);

if ($mysqli->connect_error) {
    die("❌ Verbinding mislukt: " . $mysqli->connect_error);
}
?>