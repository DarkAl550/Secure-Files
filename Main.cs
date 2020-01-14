using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureFile_v._2._0._0
{
    public partial class Main : Form
    {
        readonly FolderBrowserDialog FBD = new FolderBrowserDialog();
        readonly OpenFileDialog OFD = new OpenFileDialog();
        readonly Log logic = new Log();
        readonly Crypting cr = new Crypting();
        

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadList();


        }

        

        

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"userdata"))
            {
                logic.Open();
            }
            else
            {
                MessageBox.Show("Данный каталог спрятан!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {            
            logic.ShowHide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void listBoxSecure_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            listBoxSecure.Items.Clear();
            LoadList();
            textBox2.Clear();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text += FBD.SelectedPath + "*";
                DirectoryInfo inf = new DirectoryInfo(FBD.SelectedPath);
                listBoxUser.Items.Add(inf.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBoxUser.Items.Clear();
            textBox1.Clear();
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            logic.MoveIn(textBox1.Text, listBoxUser.Items.Count);
            
            listBoxUser.Items.Clear();
            listBoxSecure.Items.Clear();   
            textBox1.Clear();
            LoadList();

        }

        private void btnBACK_Click(object sender, EventArgs e)
        {
            if (listBoxSecure.SelectedItem == null)
            {
                MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                logic.MoveInto(cr.CryptIN(listBoxSecure.SelectedItem.ToString()));
                textBox2.Text += listBoxSecure.SelectedItem.ToString() + "\n";
                listBoxSecure.Items.Clear();
                LoadList();
            }

        }
        #region Functions

        #region LoadList()
        private void LoadList()
        {
            /* Вывод названия каталогов в listBoxSecure */
            if (Directory.Exists(@"userdata"))
            {
                string[] dirs = Directory.GetDirectories(@"userdata\");

                foreach (string folds in dirs)
                {
                    DirectoryInfo inf = new DirectoryInfo(folds);
                    listBoxSecure.Items.Add(cr.CryptOUT(inf.Name));
                }
            }
            else if (Directory.Exists(@"Locker"))
            {
                string[] dirs = Directory.GetDirectories(@"Locker\");

                foreach (string folds in dirs)
                {
                    DirectoryInfo inf = new DirectoryInfo(folds);
                    listBoxSecure.Items.Add(cr.CryptOUT(inf.Name));
                }
            }
        }
        #endregion 
        #endregion
    }
}
