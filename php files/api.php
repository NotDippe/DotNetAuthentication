<?php
function decrypt_data($encrypted) {
$password = 'password'; //this value should be the same as on .NET class
$method = 'aes-256-cbc';
$password = substr(hash('sha256', $password, true), 0, 32);
$iv = chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0);
$decrypted = openssl_decrypt(base64_decode($encrypted), $method, $password, OPENSSL_RAW_DATA, $iv);
return $decrypted;
    }
function encrypt_data($text) {
$password = 'password'; //this value should be the same as on .NET class
$method = 'aes-256-cbc';
$password = substr(hash('sha256', $password, true), 0, 32);
$iv = chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0);
$encrypted = base64_encode(openssl_encrypt($text, $method, $password, OPENSSL_RAW_DATA, $iv));
return $encrypted;
    }
?>
<?php
$p = $_POST['session'];
$session_id = decrypt_data($p);
$h = $_POST['request'];
$hwid = decrypt_data($h);
$List = file_get_contents("list" . ".txt");
if(strpos($List, $hwid) !== false)
echo encrypt_data('Whitelisted' . $session_id);
else 
echo header($_SERVER["SERVER_PROTOCOL"]." 404 Not Found");
s?>