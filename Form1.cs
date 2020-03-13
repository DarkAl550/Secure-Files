using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SecureFile_v._2._0._0
{
    public partial class Form1 : Form
    {
        readonly KeyGen gen = new KeyGen();
        readonly Main main = new Main();
        readonly User user = new User();
        readonly EmailMessage email = new EmailMessage();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartProgram();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnCheckKey_Click(object sender, EventArgs e)
        {
            Key();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #region UI
        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            tbLogin.Clear();
            tbLogin.BackColor = Color.FromArgb(87, 162, 223);
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            tbPass.Clear();
            tbPass.PasswordChar = '*';
            tbPass.BackColor = Color.FromArgb(87, 162, 223);
        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {
            tbKey.Clear();
            tbKey.BackColor = Color.FromArgb(87, 162, 223);
        }
        #endregion

        #region Functions
        private void StartProgram()
        {
            lbKey.Visible = false;
            tbKey.Visible = false;
            btnCheckKey.Visible = false;
            pictureBox1.Visible = false;
        }
        private void Login()
        {
            if (File.ReadAllLines("user.txt").Contains(tbLogin.Text) &&
                File.ReadAllLines("user.txt").Contains(tbPass.Text))
            {
                
                
                
                lbKey.Visible = true;
                tbKey.Visible = true;
                btnCheckKey.Visible = true;
                pictureBox1.Visible = true;

                button2.Visible = false;
                btnLog.Visible = false;
                lbLogin.Visible = false;
                tbLogin.Visible = false;
                lbPass.Visible = false;
                tbPass.Visible = false;
                label1.Visible = false;
                label2.Visible = false;

            }
            else if (tbLogin.Text == "guest" || tbLogin.Text == "user")
            {
                user.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверные Логин или Пароль", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Key()
        {
            CheckKey check = new CheckKey();
            if (check.Check(tbKey.Text) == true)
            {
                
                main.Show();
                Hide();
            }
        }
        #endregion

        
    }
}
