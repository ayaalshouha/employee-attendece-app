using EAS_Buissness;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employees_Attendence_System.Global
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;
        public static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\EmployeeSystemConfig";
        public static string UsernameValueName = "username";
        public static string PasswordValueName = "password";
        public static string UsernameValueData = string.Empty;
        public static string PasswordValueData = string.Empty;
        // Key for AES encryption (128-bit key)
        private static string _Key = "1234567890123456";

        static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(_Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }


        static string Decrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(_Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }


    //save username and password using Windows Registry
    public static bool SaveUsingRegistry(string usernameValue = "", string passwordValue = "")
        {
            UsernameValueData = usernameValue;
            PasswordValueData = Encrypt(passwordValue); 
            try
            {
                Registry.SetValue(KeyPath, UsernameValueName, UsernameValueData, RegistryValueKind.String);
                Registry.SetValue(KeyPath, PasswordValueName, PasswordValueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }

            return false;
        }

        public static bool getUsernamePasswordUsingRegistry(ref string usernameValue, ref string passwordValue)
        {
            try
            {
                string value1 = Registry.GetValue(KeyPath, UsernameValueName, null) as string;
                string value2 = Registry.GetValue(KeyPath, PasswordValueName, null) as string;

                if (value1 == null && value2 == null)
                {
                    usernameValue = string.Empty;
                    passwordValue = string.Empty;
                }
                else
                {
                    usernameValue = value1;
                    passwordValue = Decrypt(value2);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }

            return false;
        }

        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm

            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
