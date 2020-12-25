using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Med.SafeValue
{
    /// <summary>
    /// This class saves and loads various data types and classes using AES encryption to playerprefs.
    /// </summary>
    public static class PlayerSaves
    {
        static string key = "%D*G-KaPdSgVkYp3s6v8y/B?E(H+MbQe";

        /// <summary>
        /// The encryption key. alwayse use the same key that you used to encrypt with when decrypting otherwise you will get an error.
        /// </summary>
        public static string Key { get { return key; }
            set
            {
                if (value.Length == 32 || value.Length == 16)
                    key = value;
            }
        }

        /// <summary>
        /// Encrypts and saves your integer to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptInt(this int value, string id)
        {
            var i = new Int();
            i.x = value;
            EncryptClass(i, id);
        }

        /// <summary>
        /// Decrypts and loads your integer from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static int DecryptInt(string id)
        {
            var i = DecryptClass<Int>(id);
            return i != null ? i.x : 0;
        }

        /// <summary>
        /// Encrypts and saves your boolean to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptBool(this bool value, string id)
        {
            var bl = new Bool();
            bl.b = value;
            EncryptClass(bl, id);
        }

        /// <summary>
        /// Decrypts and loads your boolean from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static bool DecryptBool(string id)
        {
            var bl = DecryptClass<Bool>(id);
            return bl != null ? bl.b : false;
        }

        /// <summary>
        /// Encrypts and saves your string to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptString(this string value, string id)
        {
            var st = new String();
            st.s = value;
            EncryptClass(st, id);
        }

        /// <summary>
        /// Decrypts and loads your string from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static string DecryptString(string id)
        {
            var st = DecryptClass<String>(id);
            return st != null ? st.s : "";
        }

        /// <summary>
        /// Encrypts and saves your float to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptFloat(this float value, string id)
        {
            var fl = new Float();
            fl.f = value;
            EncryptClass(fl, id);
        }

        /// <summary>
        /// Decrypts and loads your float from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static float DecryptFloat(string id)
        {
            var fl = DecryptClass<Float>(id);
            return fl != null ? fl.f : 0;
        }

        /// <summary>
        /// Encrypts and saves your public fields of a class (must be Serializable) to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptClass<T>(this T obj, string id) where T : class
        {
            var data = EncryptText(JsonUtility.ToJson(obj));
            PlayerPrefs.SetString(id, data);
        }
        /// <summary>
        /// Decrypts and loads your public fields of a class (must be Serializable) from playerprefs (do not use this with MonoBehaviour or ScriptableObject, use DecryptClassOverwrite instead). 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static T DecryptClass<T>(string id) where T : class
        {
            if (PlayerPrefs.HasKey(id))
            {
                var data = DecryptText(PlayerPrefs.GetString(id));
                return JsonUtility.FromJson<T>(data);
            }
            return null;
        }

        /// <summary>
        /// Decrypts and loads your public fields of a class (must be Serializable) from playerprefs to an existing object (do not use this with MonoBehaviour or ScriptableObject, use DecryptClassOverwrite instead). 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void DecryptClassOverwrite<T>(T obj, string id)
        {
            if (PlayerPrefs.HasKey(id))
            {
                var data = DecryptText(PlayerPrefs.GetString(id));
                JsonUtility.FromJsonOverwrite(data, obj);
            }
        }

        private static string EncryptText(string plainText)
        {
            if(key.Length != 32 && key.Length != 16)
            {
                Debug.LogError("Specified key is not a valid size for this algorithm. \n" + "Make sure it is a 128bit or 256bit string");
                return "";
            }
            try
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return Convert.ToBase64String(array);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return "";
            }
        }
        public static string DecryptText(string cipherText)
        {
            try
            {
                if (cipherText.Length > 0)
                {
                    byte[] iv = new byte[16];
                    byte[] buffer = Convert.FromBase64String(cipherText);

                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = Encoding.UTF8.GetBytes(key);
                        aes.IV = iv;
                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                        using (MemoryStream memoryStream = new MemoryStream(buffer))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                                {
                                    return streamReader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
                return "";
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.Message);
                return "";
            }
        }

        [Serializable]
        class Int
        {
            public int x;
        }
        [Serializable]
        class Bool
        {
            public bool b;
        }
        [Serializable]
        class String
        {
            public string s;
        }
        [Serializable]
        class Float
        {
            public float f;
        }
    }
}
