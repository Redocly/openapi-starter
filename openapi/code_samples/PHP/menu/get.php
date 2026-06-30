<?php

// GET /menu is public — no authentication required.
$ch = curl_init('https://api.cafe.redocly.com/menu');
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

$body = curl_exec($ch);

if (curl_errno($ch)) {
    throw new RuntimeException(curl_error($ch));
}

curl_close($ch);

echo $body;
