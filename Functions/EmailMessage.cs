using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace SecureFile_v._2._0._0
{
    class EmailMessage : KeyGen
    {
        
        public void SendMessage(string email)
        {
            //FROM
            MailAddress from = new MailAddress("secure.file@yandex.by", "SecureFile");
            //TO
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Ключ активации";
            m.Body = $"Ключ для активации программы \n\n {Generate()}";
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("secure.file@yandex.by", "550JackBlack550");
            smtp.EnableSsl = true;
            smtp.Send(m);
            MessageBox.Show("Письмо отправлено");
        }
        public void SendKeyCode(string email)
        {
            //FROM
            MailAddress from = new MailAddress("secure.file@yandex.by", "SecureFile");
            //TO
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Код";
            m.Body = $"Код для подтверждения Email: {email} \n\n {GenerateCode()}";
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("secure.file@yandex.by", "550JackBlack550");
            smtp.EnableSsl = true;
            smtp.Send(m);
            MessageBox.Show("Письмо отправлено");
        }
    }
}
