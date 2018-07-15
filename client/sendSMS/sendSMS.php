<?php
 
require_once "vendor/autoload.php"; 
use Twilio\Rest\Client;
 
$account_sid = "ACc9217eb99aac7530a3aa69b27698f52b";
$auth_token = "48c996389d121c0a63b673fa5f8a8bcf";
$twilio_phone_number = "8448224702";
 
$client = new Client($account_sid, $auth_token);
 
$client->messages->create(
    '9095067621',
    array(
        "from" => $twilio_phone_number,
        "body" => "Two birds calling, like to make an appointment!"
    )
);


