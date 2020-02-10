using System.IO;
using System.Windows.Forms;

namespace SecureFile_v._2._0._0
{
    class CheckKey
    {
        private const string path = @"key.txt";
        private readonly string key = File.ReadAllText(path);

        #region Check(string a)
        public bool Check(string a)
        {

            if (key.Contains(a))
            {
                MessageBox.Show("Ключ активирован!", "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.None);
                File.AppendAllText("log.hlp", "Key was activated!");
                return true;
            }
            else
            {
                MessageBox.Show("Неверный ключ", "Ошибка ключа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
        }
        #endregion

        #region Start() Check in start
        public bool Start()
        {
            string[] strok = File.ReadAllLines("log.hlp") ;
            if (strok.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
