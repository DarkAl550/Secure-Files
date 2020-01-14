using System;
using System.IO;

namespace SecureFile_v._2._0._0
{
    class KeyGen
    {
        private const string path = @"\SecureFile\";
        private const string file = "key.txt";

        private readonly string[] ABC = { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
        private readonly string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        private readonly string Code = "q w e r t y u i o p a s d f g h j k l z x c v b n m";
        #region Generate()
        public string Generate()
        {
            Directory.CreateDirectory(path);
            Random r = new Random();

            string p1 = ABC[r.Next(0, 25)] + ABC[r.Next(0, 25)] + num[r.Next(0, 9)] + ABC[r.Next(0, 25)];
            string p2 = num[r.Next(0, 9)] + ABC[r.Next(0, 25)] + num[r.Next(0, 9)] + num[r.Next(0, 9)];
            string p3 = ABC[r.Next(0, 25)] + num[r.Next(0, 9)] + num[r.Next(0, 9)] + ABC[r.Next(0, 25)];
            string p4 = num[r.Next(0, 9)] + ABC[r.Next(0, 25)] + ABC[r.Next(0, 25)] + ABC[r.Next(0, 25)];

            string key = p1 + "-" + p2 + "-" + p3 + "-" + p4 ;

            File.AppendAllText(file, key + "\n");

            return key;
        }
        public string GenerateCode()
        {
            Directory.CreateDirectory(path);
            Random rand = new Random();
            string[] codekey = Code.Split(new char[] { ' ' });

            string code = codekey[rand.Next(0, 25)] + codekey[rand.Next(0, 25)] +
                ABC[rand.Next(0, 25)] + codekey[rand.Next(0, 25)] + ABC[rand.Next(0, 25)] +
                codekey[rand.Next(0, 25)];

            File.AppendAllText("code.txt", code);

            return code;
        }
        #endregion
    }
}
