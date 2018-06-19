'use strict'
const merge = require('webpack-merge')
const devEnv = require('./dev.env')

module.exports = merge(devEnv, {
    NODE_ENV: '"testing"',
    PUBLIC_KEY: '"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlnix2KuaKMyFOj3ZGPYNpRdPEarj6u8zUvy0RPATyPv346+x+9RoqHXH9uBJTsbQ2cBmYi0oEkHsqLTebff6PAvTfHiyBKJe1khmWtbwVJRXfRN/hK3jbobREm/GXoJKV7VZCVL3fkND7Pfhkc9WkhH7h0//4dH3vB0ww8o5jGtMn2Rh92eGylyoBd8KcS0+j7mywHe17KS+++MTCkU3Hnh4Xx2We0v3RSb/lC8/SdIe++3TsbPeQ5ICTM2K01oGiqqZGZqD5xLhXWQW5e8Ib6oems/iY2t/B6CosDkeHo0b6XBGis7J/ggjz0SJDA1/NbCF/cIANLlk6/Qwqk1SVwIDAQAB"',
    AES_KEY: '"aaaazzzzoooommmm"',
    MERCHANT_ID: '"CS01"',
    USER_KEY: '"5d39980acc6e4d6f91b04720c3414ef6"',
    KEY: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']
})