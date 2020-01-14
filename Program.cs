using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureFile_v._2._0._0
{
    static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Registration());
            #region Prodaction
            CheckKey ch = new CheckKey();
            bool c = ch.Start();
            if (c == false)
            {
                Application.Run(new Main());
            }
            else
            {

                Application.Run(new Form1());
            }
            #endregion
        }
    }
}
