<?php

date_default_timezone_set("America/Sao_Paulo");
if(isset($_FILES['file'])){
    $uploads_dir = './files'; //Directory to save the file that comes from client application.
    if ($_FILES["file"]["error"] == UPLOAD_ERR_OK) {
        $tmp_name = $_FILES["file"]["tmp_name"];
        $data = date('dmY His');
        $name = $_FILES["file"]["name"];
        move_uploaded_file($tmp_name, "$uploads_dir/$data.$name");
    }
}
?>

<form action="http://localhost" method='POST' enctype="multipart/form-data">
    <input type="file" name="file" id="file">
    <input type="submit" value="Enviar">
</form>

<?php
    $d = dir("files/");
    while($ar = $d->read())
    {
        echo "<a href='files/${ar}'>${ar}</a><br>";
    }
?>