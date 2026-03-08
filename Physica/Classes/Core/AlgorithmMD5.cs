
// Source - https://stackoverflow.com/a/6839784
// Posted by Dmitry Polomoshnov, modified by community. See post 'Timeline' for change history
// Retrieved 2026-03-08, License - CC BY-SA 4.0

using System.Security.Cryptography;
using System.Text;

namespace Physica.Classes.Core
{
    internal class AlgorithmMD5
    {
        public static byte[] GetHash(string inputString)
        {
            return MD5.HashData(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2").ToLower());

            return sb.ToString();
        }
    }
}
