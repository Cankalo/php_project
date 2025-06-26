<?php
session_start();
if (!isset($_SESSION['gebruiker'])) {
    header("Location: login.php");
    exit;
}
?>
<!DOCTYPE html>
<html>
<head>
  <title>Stemtest</title>
</head>
<body>
  <h2>Maak de stemtest</h2>
  <p>Hier komen jouw vragen, antwoorden en berekeningen.</p>
</body>
</html>
