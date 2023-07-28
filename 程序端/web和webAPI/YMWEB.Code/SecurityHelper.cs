﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YMWeb.Code
{
    public class SecurityHelper
    {
        public static string SerializeObjectDictionary(Dictionary<string, string> dict, string applicationHostName = "")
        {
            try
            {
                StringBuilder sbuilder = new StringBuilder();
                sbuilder.Append("{");
                bool isFirst = true;
                foreach (var key in dict.Keys)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        sbuilder.Append(",");
                    sbuilder.Append("\"" + key.Replace("\"", "\\\"") + "\":\"" + dict[key].Replace("\"", "\\\"") + "\"");
                }
                sbuilder.Append("}");
                return sbuilder.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string GetSafeDictionaryKey(Dictionary<string, string> dict, string key, string applicationHostName = "")
        {
            if (dict == null || string.IsNullOrEmpty(key))
                return null;

            if (dict.ContainsKey(key))
                return dict[key];
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Md5秘钥
        /// </summary>
        private static string _md5Key = "?,.><>23dsfa{}.[]asfdvas3tgrvfvbsadf5ds";
        /// <summary>
        /// Creates an instance of the specified implementation of the MD5 hash algorithm.
        /// 创建MD5哈希算法的指定实现的实例。
        /// </summary>
        /// <param name="source">The string of the specific implementation of MD5 to use.字符串的MD5的具体实现使用</param>
        /// <returns>A new string of the specified implementation of MD5.指定的MD5实现的新字符串</returns>
        public static string Md5(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(source + _md5Key);
            byte[] output = md5.ComputeHash(bytes);
            return BitConverter.ToString(output);
        }
        public static string Md5NoSeparators(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            return Md5(source).Replace("-", "");
        }


        private static string _desKey = "";


        private static string DesKey
        {
            get
            {
                if (_desKey.Length < 2)
                {
                    _desKey = "inmediaR%^&^%d";//改为配置读取秘钥 TODO
                }
                return _desKey;
            }
        }
        /// <summary>
        /// 加密Creates a symmetric data encryption standard (des) encryptor object.
        /// </summary>
        /// <param name="source">The string of the specific implementation of DES to use.</param>
        /// <returns>A new encrypted string.</returns>
        public static string DesEncrypt(string source)
        {
            var key = DesKey;//".!e@0Na&";
            if (key.Length > 8)
                key = key.Substring(0, 8);
            var des = new DESCryptoServiceProvider();

            byte[] bytes = Encoding.UTF8.GetBytes(source);

            byte[] bytes2 = Encoding.ASCII.GetBytes(key);
            des.Key = bytes2;
            des.IV = bytes2;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(bytes, 0, bytes.Length);
            cs.FlushFinalBlock();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                sb.AppendFormat("{0:X2}", b);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 解密 Creates a symmetric data encryption standard (des) decrypted object.
        /// </summary>
        /// <param name="source">encrypted string</param>
        /// <param name="key"></param>
        /// <param name="ApplicationHostName"></param>
        /// <returns>A new decrypted string</returns>
        public static string DesDecrypt(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            var key = DesKey;//".!e@0Na&";
            if (key.Length > 8)
                key = key.Substring(0, 8);
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] bytes = new byte[source.Length / 2];
                for (int x = 0; x < source.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(source.Substring(x * 2, 2), 16));
                    bytes[x] = (byte)i;
                }

                byte[] bytes2 = ASCIIEncoding.ASCII.GetBytes(key);
                des.Key = bytes2;
                des.IV = bytes2;

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(bytes, 0, bytes.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="applicationHostName"></param>
        /// <returns></returns>
        public static string RsaEncrypt(string content, string applicationHostName = "")
        {
            string publickey = "";
            if (string.IsNullOrEmpty(publickey))
                publickey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            try
            {
                byte[] messagebytes = Encoding.UTF8.GetBytes(content);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publickey);
                int maxBlockSize = rsa.KeySize / 8 - 11;

                if (messagebytes.Length <= maxBlockSize)
                    return Convert.ToBase64String(rsa.Encrypt(messagebytes, false));

                using (MemoryStream msInput = new MemoryStream(messagebytes))
                using (MemoryStream msOuput = new MemoryStream())
                {
                    Byte[] buffer = new Byte[maxBlockSize];
                    int blockSize = msInput.Read(buffer, 0, maxBlockSize);
                    while (blockSize > 0)
                    {
                        Byte[] toEncrypt = new Byte[blockSize];
                        Array.Copy(buffer, 0, toEncrypt, 0, blockSize);

                        Byte[] cryptograph = rsa.Encrypt(toEncrypt, false);
                        msOuput.Write(cryptograph, 0, cryptograph.Length);

                        blockSize = msInput.Read(buffer, 0, maxBlockSize);
                    }

                    return Convert.ToBase64String(msOuput.ToArray(), Base64FormattingOptions.None);
                }
            }
            catch (CryptographicException ex)
            {
            }
            return string.Empty;
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="applicationHostName"></param>
        /// <returns></returns>
        public static string RsaDecrypt(string content, string applicationHostName = "")
        {


            string privatekey = "";//TODO
            if (string.IsNullOrEmpty(privatekey))
                privatekey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent><P>/hf2dnK7rNfl3lbqghWcpFdu778hUpIEBixCDL5WiBtpkZdpSw90aERmHJYaW2RGvGRi6zSftLh00KHsPcNUMw==</P><Q>6Cn/jOLrPapDTEp1Fkq+uz++1Do0eeX7HYqi9rY29CqShzCeI7LEYOoSwYuAJ3xA/DuCdQENPSoJ9KFbO4Wsow==</Q><DP>ga1rHIJro8e/yhxjrKYo/nqc5ICQGhrpMNlPkD9n3CjZVPOISkWF7FzUHEzDANeJfkZhcZa21z24aG3rKo5Qnw==</DP><DQ>MNGsCB8rYlMsRZ2ek2pyQwO7h/sZT8y5ilO9wu08Dwnot/7UMiOEQfDWstY3w5XQQHnvC9WFyCfP4h4QBissyw==</DQ><InverseQ>EG02S7SADhH1EVT9DD0Z62Y0uY7gIYvxX/uq+IzKSCwB8M2G7Qv9xgZQaQlLpCaeKbux3Y59hHM+KpamGL19Kg==</InverseQ><D>vmaYHEbPAgOJvaEXQl+t8DQKFT1fudEysTy31LTyXjGu6XiltXXHUuZaa2IPyHgBz0Nd7znwsW/S44iql0Fen1kzKioEL3svANui63O3o5xdDeExVM6zOf1wUUh/oldovPweChyoAdMtUzgvCbJk1sYDJf++Nr0FeNW1RB1XG30=</D></RSAKeyValue>";

            try
            {
                byte[] messagebytes = Convert.FromBase64String(content);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privatekey);
                int maxBlockSize = rsa.KeySize / 8;

                if (messagebytes.Length <= maxBlockSize)
                    return Encoding.UTF8.GetString(rsa.Decrypt(messagebytes, false));

                using (MemoryStream msInput = new MemoryStream(messagebytes))
                using (MemoryStream msOuput = new MemoryStream())
                {
                    Byte[] buffer = new Byte[maxBlockSize];
                    int blockSize = msInput.Read(buffer, 0, maxBlockSize);

                    while (blockSize > 0)
                    {
                        Byte[] toDecrypt = new Byte[blockSize];
                        Array.Copy(buffer, 0, toDecrypt, 0, blockSize);

                        Byte[] plaintext = rsa.Decrypt(toDecrypt, false);
                        msOuput.Write(plaintext, 0, plaintext.Length);

                        blockSize = msInput.Read(buffer, 0, maxBlockSize);
                    }

                    return Encoding.UTF8.GetString(msOuput.ToArray());
                }
            }
            catch (CryptographicException ex)
            {
            }
            return string.Empty;
        }
        /// <summary>
        /// unix Timestamp转换为DateTIme
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        public static string Decrypt(string cipherText)
        {

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Convert.FromBase64String("empmd0BneGRhdGF3YXleMXFhenhzdzIzZWRjdmZyNCM=");
                aesAlg.IV = Convert.FromBase64String("Z3hkYXRhd2F5LnpqZndeIw==");
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;

        }
        /// <summary>
        /// 字符串转base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string getBase64(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            //转成 Base64 形式的 System.String  
            str = Convert.ToBase64String(b);
            return str;

        }

        /// <summary>
        /// base64还原字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string fromBase64(string str)
        {
            byte[] c = Convert.FromBase64String(str);
            str = Encoding.Default.GetString(c);
            return str;
        }
    }
}