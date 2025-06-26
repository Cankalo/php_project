<?php
session_start();
if (!isset($_SESSION['gebruiker'])) {
    header("Location: ../login.php");
    exit;
}
?>
<!DOCTYPE html>
<html>
<head><title>Dashboard</title></head>
<body>
  <h2>Welkom, <?php echo $_SESSION['gebruiker']; ?>!</h2>
  <p><a href="../stemtest.php">Ga naar de stemtest</a></p>
  <p><a href="../logout.php">Uitloggen</a></p>
</body>
</html>
