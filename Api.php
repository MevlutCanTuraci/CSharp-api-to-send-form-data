<?php 


extract($_POST);

echo "User name : $userName \r\n\n";

echo "Type : $type \r\n\n";

$file = $_FILES["image"];

$tag = rand(1, 99999);

$newName = "image_$tag";

$imageName    = $newName . ".png";
$filePath     = $imageName; 

move_uploaded_file($_FILES["image"]["tmp_name"], $filePath); 

echo "File saved";