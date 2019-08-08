import CryptoJS from "crypto-js";
import JSEncrypt from "jsencrypt";
const PUBLIC_KEY =
    "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlnix2KuaKMyFOj3ZGPYNpRdPEarj6u8zUvy0RPATyPv346+x+9RoqHXH9uBJTsbQ2cBmYi0oEkHsqLTebff6PAvTfHiyBKJe1khmWtbwVJRXfRN/hK3jbobREm/GXoJKV7VZCVL3fkND7Pfhkc9WkhH7h0//4dH3vB0ww8o5jGtMn2Rh92eGylyoBd8KcS0+j7mywHe17KS+++MTCkU3Hnh4Xx2We0v3RSb/lC8/SdIe++3TsbPeQ5ICTM2K01oGiqqZGZqD5xLhXWQW5e8Ib6oems/iY2t/B6CosDkeHo0b6XBGis7J/ggjz0SJDA1/NbCF/cIANLlk6/Qwqk1SVwIDAQAB";
const AES_KEY = "aaaazzzzoooommmm";
const MERCHANT_ID = "CS01";
const USER_KEY = "5d39980acc6e4d6f91b04720c3414ef6";
const KEY =
    "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
/**
 * 加密服务
 */
export default {
    /**
     * 实体加密（RSA证书加密）
     * @param {*} model
     * @param {*} isEncryption
     */
    dataRSAEncryption(model, isEncryption = false) {
        let encryptionModel = {
            MerchantId: null,
            Data: null,
            EncryptKey: null
        };

        encryptionModel.MerchantId = MERCHANT_ID;
        let ran_aesKEY = this.generateAESKey();
        model.Ip = "167.0.12.31";
        model.Mac = "00-15-5D-7E-36-5B";
        model.IsValid = true;
        model.Version = "1.0.0";
        model.TimesTamp = this.getTimesTamp();
        model.Sign = null;

        if (isEncryption) {
            //新版本
            mode.Sign = this.getSign(
                encryptionModel.MerchantId,
                mode.TimesTamp,
                mode.Ip,
                mode.Mac
            );
            //老版本
            //model.Sign = (CryptoJS.MD5(JSON.stringify(model) + USER_KEY) + "").toUpperCase();
        }

        encryptionModel.Data = this.AESEncrypt(JSON.stringify(model), ran_aesKEY);
        encryptionModel.EncryptKey = this.RSAEncrypt(ran_aesKEY);

        return encryptionModel;
    },
    /**
     * 实体加密（明参）
     * @param {*} model 
     * @param {*} isEncryption 
     */
    dataEncryption(model, isEncryption = false) {
        model.MerchantId = MERCHANT_ID;
        model.Ip = "167.0.12.31";
        model.Mac = "00-15-5D-7E-36-5B";
        model.IsValid = true;
        model.Version = "1.0.0";
        model.TimesTamp = this.getTimesTamp();
        model.Sign = null;

        if (isEncryption) {
            //新版本
            model.Sign = this.getSign(
                MERCHANT_ID,
                model.TimesTamp,
                model.Ip,
                model.Mac
            );
            //旧版本
            //model.Sign = (CryptoJS.MD5(JSON.stringify(model) + USER_KEY) + "").toUpperCase();
        }

        return model;
    },
    /* 获取Md5加密sign值
     * @param {*} MerchantId 商户编号
     * @param {*} TimesTamp 时间戳
     * @param {*} Ip IP地址
     * @param {*} Mac MAC
     */
    getSign(MerchantId, TimesTamp, Ip, Mac) {
        let jsonData = `MerchantId=${MerchantId}&TimesTamp=${TimesTamp}&Ip=${Ip}&Mac=${Mac}${USER_KEY}`;
        let sign = CryptoJS.MD5(jsonData) + "";
        return sign.toUpperCase();
    },
    /**
     * 获取时间戳
     */
    getTimesTamp() {
        let date = new Date();

        let fullYear = date.getFullYear();
        let month = date.getMonth();
        let day = date.getDate();
        let hours = date.getHours();
        let minutes = date.getMinutes();
        let seconds = date.getSeconds();
        let milliseconds = date.getMilliseconds();

        let timesTamp = Date.UTC(
            fullYear,
            month,
            day,
            hours,
            minutes,
            seconds,
            milliseconds
        );

        return timesTamp;
    },
    /**
     * 生成16位AES - KEY
     */
    generateAESKey() {
        let k = KEY.split(",");
        let keyLength = k.length;
        let m = 0;
        let n = keyLength - 1;
        let str = "";

        for (let index = 0; index < 16; index++) {
            let ran = Math.random() * (n - m) + m;
            str = str + KEY[parseInt(ran.toString())];
        }

        return str;
    },
    /**
     * AES数据解密
     * @param {*} data 要解密的数据
     * @param {*} key 16位AES_KEY
     */
    AESDecrypt(data, key) {
        let k = CryptoJS.enc.Utf8.parse(key);
        let i = CryptoJS.enc.Utf8.parse(key);

        let decrypted = CryptoJS.AES.decrypt(data, k, {
            iv: i,
            mode: CryptoJS.mode.ECB,
            padding: CryptoJS.pad.Pkcs7
        });

        let decryptedUtf8Str = decrypted.toString(CryptoJS.enc.Utf8);
        return decryptedUtf8Str;
    },
    /**
     * RSA加密
     * @param {*} aesKey AES 加密数据
     */
    RSAEncrypt(aesKey) {
        let encrypt = new JSEncrypt();
        encrypt.setPublicKey(PUBLIC_KEY);
        let aeskey = encrypt.encrypt(aesKey);
        return aeskey;
    },
    /**
     * URL 参数加密
     * @param {*} str 要加密的参数
     */
    UrlEncode(str) {
        return encodeURI(str);
    },
    /**
     * URL 参数解密
     * @param {*} str 要解密的参数
     */
    UrlDecode(str) {
        return decodeURI(str);
    },
    /**
     * MD5加密
     * @param {*} object 要加密的字符
     */
    MD5Encryption(object = "1234567890", isLowerCase = true) {
        if (isLowerCase) {
            return (CryptoJS.MD5(object) + "").toLowerCase();
        } else {
            return (CryptoJS.MD5(object) + "").toUpperCase();
        }
    }
};