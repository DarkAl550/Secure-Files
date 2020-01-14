using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SecureFile_v._2._0._0
{
    class Log : Crypting
    {
        

        private const string path = @"userdata\";
        private const string securePath = @"Locker\";
        private const string backpath = @"\";

        #region ShowHide()
        public void ShowHide()
        {
            Process.Start("lock.bat");
        }
        #endregion

        #region Moving
        public void MoveIn(string file, int N)
        {
            string[] files = file.Split(new char[] { '*' });

            if (Directory.Exists(@"userdata"))
            {
                for (int i = 0; i < N; i++)
                {
                    DirectoryInfo dir = new DirectoryInfo(files[i]);
                    dir.MoveTo(path + CryptIN(dir.Name));
                }
            }
            else if (Directory.Exists(@"Locker"))
            {
                for (int i = 0; i < N; i++)
                {
                    DirectoryInfo dir = new DirectoryInfo(files[i]);
                    dir.MoveTo(securePath + CryptIN(dir.Name));
                }
            }


        }
        /* Перемещение каталогов и файлов из скрытой папки  */
        public void MoveInto(string name)
        {
            string file1 = path + name + "*";
            string file2 = securePath + name + "*";
            string[] files1 = file1.Split(new char[] { '*' });
            string[] files2 = file2.Split(new char[] { '*' });

            if (Directory.Exists(@"userdata"))
            {
                DirectoryInfo dir = new DirectoryInfo(files1[0]);
                dir.MoveTo(backpath + CryptOUT(dir.Name));
            }
            else if (Directory.Exists(@"Locker"))
            {
                DirectoryInfo dir = new DirectoryInfo(files2[0]);
                dir.MoveTo(backpath + CryptOUT(dir.Name));
            }


        }
        #endregion

        #region Open()
        public void Open()
        {
            
            Process.Start("explorer", path);
        }
        #endregion

    }
}
