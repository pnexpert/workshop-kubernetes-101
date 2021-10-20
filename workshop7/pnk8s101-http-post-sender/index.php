<html>
<h2>
Send POST request to Ambassador.
<?php
$random = rand();
echo " Random: $random";
shell_exec("sh ambassador.sh $random");
?>
</h2>
</html>
