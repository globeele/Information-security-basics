using System;
using System.Text;

namespace Lib_Lab_2
{
    public class GammaОverlay
    {
        public byte[] encode(string pText, string pKey)
        {
            byte[] txt = Encoding.ASCII.GetBytes(pText);
            byte[] key = Encoding.ASCII.GetBytes(pKey);
            byte[] res = new byte[pText.Length];

            for (int i = 0; i < txt.Length; i++)
            {
                res[i] = (byte)(txt[i] ^ key[i % key.Length]);
            }

            return res;
        }

        public string decode(byte[] pText, string pKey)
        {
            byte[] res = new byte[pText.Length];
            byte[] key = Encoding.ASCII.GetBytes(pKey);

            for (int i = 0; i < pText.Length; i++)
            {
                res[i] = (byte)(pText[i] ^ key[i % key.Length]);
            }

            return Encoding.ASCII.GetString(res);
        }
    }
}
