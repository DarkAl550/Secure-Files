using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureFile_v._2._0._0
{
    class Crypting
    {
        private const string abcRU = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
        private const string abcEN = "QWERTYUIOPASDFGHJKLZXCVBNM";



        #region ShifrRU(string text, int k)
        private string ShifrRU(string text, int k)
        {
            var ABC = abcRU + abcRU.ToLower();
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = ABC.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (ABC.Length + index + k) % ABC.Length;
                    retVal += ABC[codeIndex];
                }
            }
            return retVal;

        }
        private string EncryptRU(string plainMessage, int key) => ShifrRU(plainMessage, key);

        private string DecryptRU(string encryptedMessage, int key) => ShifrRU(encryptedMessage, -key);
        #endregion

        #region ShifrEN(string text, int k)
        private string ShifrEN(string text, int k)
        {
            var ABC = abcEN + abcEN.ToLower();
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = ABC.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (ABC.Length + index + k) % ABC.Length;
                    retVal += ABC[codeIndex];
                }
            }
            return retVal;

        }
        private string EncryptEN(string plainMessage, int key) => ShifrEN(plainMessage, key);

        private string DecryptEN(string encryptedMessage, int key) => ShifrEN(encryptedMessage, -key);
        #endregion
       
        #region CryptIN/OUT(string text)
        public string CryptIN(string text)
        {
            byte[] b = Encoding.Default.GetBytes(text);
            string tx = null;
            foreach(byte bt in b)
            {
                if((bt >= 97) && (bt <= 122))
                {
                    //EN
                   tx =  EncryptEN(text, 5);
                    
                }
                if((bt >= 192) && (bt <= 239))
                {
                    //RU
                    tx = EncryptRU(text, 5);
                    
                }
                
            }
            return tx;

        }
        public string CryptOUT(string text)
        {
            byte[] b = Encoding.Default.GetBytes(text);
            string tx = null; ;
            foreach (byte bt in b)
            {
                if ((bt >= 97) && (bt <= 122))
                {
                    //EN
                     tx = DecryptEN(text, 5);
                }
                if ((bt >= 192) && (bt <= 239))
                {
                    //RU
                    tx = DecryptRU(text, 5);
                }
            }
            return tx;
        }
        #endregion
    }
}
