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
        public static string Key { get => key;
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
        public static void EncryptInt(this int value, string prefKey)
        {
            var i = new Int();
            i.x = value;
            EncryptClass(i, prefKey);
        }

        /// <summary>
        /// Decrypts and loads your integer from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static int DecryptInt(string prefKey, int defaultValue = default)
        {
            var i = DecryptClass<Int>(prefKey);
            return i != null ? i.x : defaultValue;
        }

        /// <summary>
        /// Encrypts and saves your boolean to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptBool(this bool value, string prefKey)
        {
            var bl = new Bool();
            bl.b = value;
            EncryptClass(bl, prefKey);
        }

        /// <summary>
        /// Decrypts and loads your boolean from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static bool DecryptBool(string prefKey, bool defaultValue = default)
        {
            var bl = DecryptClass<Bool>(prefKey);
            return bl != null ? bl.b : defaultValue;
        }

        /// <summary>
        /// Encrypts and saves your string to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptString(this string value, string prefKey)
        {
            var st = new String();
            st.s = value;
            EncryptClass(st, prefKey);
        }

        /// <summary>
        /// Decrypts and loads your string from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static string DecryptString(string prefKey, string defaultValue = default)
        {
            var st = DecryptClass<String>(prefKey);
            return st != null ? st.s : defaultValue;
        }

        /// <summary>
        /// Encrypts and saves your float to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptFloat(this float value, string prefKey)
        {
            var fl = new Float();
            fl.f = value;
            EncryptClass(fl, prefKey);
        }

        /// <summary>
        /// Decrypts and loads your float from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static float DecryptFloat(string prefKey, float defaultValue = default)
        {
            var fl = DecryptClass<Float>(prefKey);
            return fl != null ? fl.f : defaultValue;
        }

        /// <summary>
        /// Encrypts and saves your char to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptChar(this char value, string prefKey)
        {
            var ch = new Char();
            ch.c = value;
            EncryptClass(ch, prefKey);
        }

        /// <summary>
        /// Decrypts and loads your char from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static char DecryptChar(string prefKey, char defaultValue = default)
        {
            var ch = DecryptClass<Char>(prefKey);
            return ch != null ? ch.c : defaultValue;
        }


        /// <summary>
        /// Encrypts and saves your long to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptLong(this long value, string prefKey)
        {
            var lg = new Long();
            lg.l = value;
            EncryptClass(lg, prefKey);
        }

        /// <summary>
        /// Decrypts and loads your long from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static long DecryptLong(string prefKey, long defaultValue = default)
        {
            var lg = DecryptClass<Long>(prefKey);
            return lg != null ? lg.l : defaultValue;
        }

        /// <summary>
        /// Encrypts and saves your DateTime to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptDateTime(this DateTime value, string prefKey)
        {
            var lg = new Long();
            lg.l = value.Ticks;
            EncryptClass(lg, prefKey);
        }

        /// <summary>
        /// Decrypts and loads your DateTime from playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static DateTime DecryptDateTime(string prefKey, DateTime defaultValue = default)
        {
            var lg = DecryptClass<Long>(prefKey);
            DateTime dt = lg != null ? new DateTime(lg.l) : defaultValue;
            return dt;
        }

        /// <summary>
        /// Encrypts and saves your public fields of a class (must be Serializable) to playerprefs. 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void EncryptClass<T>(this T obj, string prefKey) where T : class
        {
            var data = EncryptText(JsonUtility.ToJson(obj));
            PlayerPrefs.SetString(prefKey, data);
        }
        /// <summary>
        /// Decrypts and loads your public fields of a class (must be Serializable) from playerprefs (do not use this with MonoBehaviour or ScriptableObject, use DecryptClassOverwrite instead). 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static T DecryptClass<T>(string prefKey) where T : class
        {
            if (PlayerPrefs.HasKey(prefKey))
            {
                var data = DecryptText(PlayerPrefs.GetString(prefKey));
                return JsonUtility.FromJson<T>(data);
            }
            return null;
        }

        /// <summary>
        /// Decrypts and loads your public fields of a class (must be Serializable) from playerprefs to an existing object (do not use this with MonoBehaviour or ScriptableObject, use DecryptClassOverwrite instead). 
        /// Note: Will use a default key if the Key property is not set.
        /// </summary>
        public static void DecryptClassOverwrite<T>(T obj, string prefKey)
        {
            if (PlayerPrefs.HasKey(prefKey))
            {
                var data = DecryptText(PlayerPrefs.GetString(prefKey));
                JsonUtility.FromJsonOverwrite(data, obj);
            }
        }

        /// <summary>
        /// Returns true if the prefKey provided exists.
        /// </summary>
        public static bool HasPrefKey(string prefKey) => PlayerPrefs.HasKey(prefKey);

        /// <summary>
        /// Migrates the value stored for one key to an other key. This can be useful if you want to
        /// rename a PlayerPrefs key, but without existing data stored at the old key from being lost.
        /// </summary>
        /// <param name="oldKey">The old key to move data from.</param>
        /// <param name="newKey">The new key to store the data for.</param>
        /// <param name="deleteOldKey">Whether to delete the old key or not.</param>
        /// <returns>
        /// Returns true if the migration operation is successful.
        /// </returns>
        public static bool MigratePrefKey(string oldKey, string newKey, bool deleteOldKey = true)
        {
            if (HasPrefKey(oldKey))
            {
                var oldKeyValue = PlayerPrefs.GetString(oldKey);
                PlayerPrefs.SetString(newKey, oldKeyValue);
                if (deleteOldKey)
                    DeletePrefKey(oldKey);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes prefKey and its corresponding value.
        /// </summary>
        public static void DeletePrefKey(string prefKey) => PlayerPrefs.DeleteKey(prefKey);

        /// <summary>
        /// Deletes all the prefKeys and all their corresponding values.
        /// </summary>
        public static void DeleteAllPrefKeys() => PlayerPrefs.DeleteAll();

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
        [Serializable]
        class Char
        {
            public char c;
        }
        [Serializable]
        class Long
        {
            public long l;
        }

    }
}
