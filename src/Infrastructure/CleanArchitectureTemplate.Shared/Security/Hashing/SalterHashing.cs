using System;
using System.Text;
using System.Security.Cryptography;


namespace CleanArchitectureTemplate.Shared.Security.Hashing
{
    public class SalterHashing
    {
        private static string HashGenerator(string text, HashType hashType)
        {
            byte[] textArr = Encoding.Unicode.GetBytes(text);
            byte[] MyHashData = HashAlgorithm.Create(hashType.ToString()).ComputeHash(textArr);
            return Convert.ToBase64String(MyHashData);
        }

        public static string PasswordGenerator(string clearText)
        {
            return HashGenerator(clearText, HashType.MD5) + HashGenerator(clearText.Substring(0, clearText.Length / 3), HashType.SHA384);
        }
    }
}
