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
    public partial class Registration : Form
    {
        readonly EmailMessage email = new EmailMessage();
        public Registration()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            Registr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewPassword();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            Hide();
        }

        #region UI
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            tbName.Clear();
            tbName.BackColor = Color.FromArgb(87, 162, 223);
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            tbEmail.Clear();
            tbEmail.BackColor = Color.FromArgb(87, 162, 223);
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            tb.Clear();
            tb.BackColor = Color.FromArgb(87, 162, 223);
        }

        private void tbCPass_TextChanged(object sender, EventArgs e)
        {
            tbCPass.Clear();
            tbCPass.BackColor = Color.FromArgb(87, 162, 223);
        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {
            tbKey.Clear();
            tbKey.BackColor = Color.FromArgb(87, 162, 223);
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            tbPass.Clear();
            tbPass.PasswordChar = '*';
            tbPass.BackColor = Color.FromArgb(87, 162, 223);
        }
        #endregion

        #region Functions

        #region CheckTextBox()
        void CheckTextBox()
        {
            if (tbName.Text == "" || tbEmail.Text == "" ||
                tbPass.Text == "" || tbCPass.Text == "")
            {
                label1.Visible = true;
                label1.Text = "❌";
                label1.ForeColor = Color.FromArgb(255, 0, 0);

                label2.Visible = true;
                label2.Text = "❌";
                label2.ForeColor = Color.FromArgb(255, 0, 0);

                label3.Visible = true;
                label3.Text = "❌";
                label3.ForeColor = Color.FromArgb(255, 0, 0);

                label4.Visible = true;
                label4.Text = "❌";
                label4.ForeColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show($"Требуеться заполнить каждое поле!");
            }
            else
            {
                if (Validations() == 4)
                {
                    Enable();
                    email.SendKeyCode(tbEmail.Text);

                    File.AppendAllText("user.txt", tbEmail.Text + "\n" + tbPass.Text + "\n" + tbName.Text);
                    MessageBox.Show($"На Email:{tbEmail.Text} отправлено сообщение с кодом подтверждения");
                }
                
            }
        }
        #endregion

        #region Enable()
        void Enable()
        {
            lbKey.Visible = true;
            tbKey.Visible = true;
            btnAccept.Visible = true;
            btnReg.Visible = false;
            tbName.Enabled = false;
            tbEmail.Enabled = false;
            tbPass.Enabled = false;
            tbCPass.Enabled = false;
            tb.Enabled = false;
            button1.Enabled = false;

        }
        #endregion

        #region Validations()
        private int Validations()
        {
            int count = 0;
            if(tbName.Text.Length < 4 || tbName.Text == null)
            {
                MessageBox.Show("Имя пользователя должно содержать не менее 4 символов!");
                label1.Visible = true;
                label1.Text = "❌";
                label1.ForeColor = Color.FromArgb(255, 0, 0);
            }
            else
            {
                label1.Visible = true;
                label1.Text = "✔";
                label1.ForeColor = Color.FromArgb(0, 255, 0);
                count++;
            }

            if (tbEmail.Text.Contains("@") && tbEmail.Text.Contains("."))
            {
                label2.Visible = true;
                label2.Text = "✔";
                label2.ForeColor = Color.FromArgb(0, 255, 0);
                count++;
            }
            else
            {
                label2.Visible = true;
                label2.Text = "❌";
                label2.ForeColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("Неверный форма Email");
            }
            if(tbPass.Text.Length < 6 || tbPass.Text == null)
            {
                label3.Visible = true;
                label3.Text = "❌";
                label3.ForeColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("Пароль не надежный! Пароль должен содеражать не менее 6 символов!");
            }
            else
            {
                label3.Visible = true;
                label3.Text = "✔";
                label3.ForeColor = Color.FromArgb(0, 255, 0);
                count++;
            }
            if(tbPass.Text == tbCPass.Text)
            {
                label4.Visible = true;
                label4.Text = "✔";
                label4.ForeColor = Color.FromArgb(0, 255, 0);
                count++;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!");
                label4.Visible = true;
                label4.Text = "❌";
                label4.ForeColor = Color.FromArgb(255, 0, 0);
            }
            return count;
        }
        #endregion

        #region ViewPassword()
        private void ViewPassword()
        {
            tbPass.Visible = false;
            tb.Visible = true;
            tb.Text = tbPass.Text;
        }
        #endregion

        #region CheckCode()
        private void CheckCode()
        {
            if(File.ReadAllLines("code.txt").Contains(tbKey.Text))
            {
                MessageBox.Show("Регистрация прошла успешно!");
                File.Delete("code.txt");
                Form1 log = new Form1();
                log.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный код!");
            }
        }
        #endregion

        #region Registr()
        private void Registr()
        {
            CheckTextBox();
            
        }
        #endregion

        #region Accept()
        private void Accept()
        {
            CheckCode();
            MessageBox.Show($"На данную почту будет отправлено письмо с ключом!");
            email.SendMessage(tbEmail.Text);
        }
        #endregion

        #endregion

        
    }
}
