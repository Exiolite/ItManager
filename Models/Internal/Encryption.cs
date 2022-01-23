using System.Security.Cryptography;
using System.Text;

class Encryption
{
    public static byte[] Encrypt(string original, string password)
    {
        using (RijndaelManaged myRijndael = new())
        {
            var Key = Encoding.ASCII.GetBytes(password);
            var IV = Encoding.ASCII.GetBytes("Exiolite20212022");
            return EncryptStringToBytes(original, Key, IV);
        }
    }

    public static string Decrypt(byte[] original, string password)
    {
        using (RijndaelManaged myRijndael = new())
        {
            var Key = Encoding.ASCII.GetBytes(password);
            var IV = Encoding.ASCII.GetBytes("Exiolite20212022");
            return DecryptStringFromBytes(original, Key, IV);
        }
    }
    static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");
        byte[] encrypted;

        using (RijndaelManaged rijAlg = new())
        {
            rijAlg.Padding = PaddingMode.ANSIX923;
            ICryptoTransform encryptor = rijAlg.CreateEncryptor(Key, IV);
            using (MemoryStream msEncrypt = new())
            {
                using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");

        string plaintext = null;
        using (RijndaelManaged rijAlg = new())
        {
            rijAlg.Padding = PaddingMode.ANSIX923;
            ICryptoTransform decryptor = rijAlg.CreateDecryptor(Key, IV);
            using (MemoryStream msDecrypt = new(cipherText))
            {
                using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
}