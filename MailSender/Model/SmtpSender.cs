using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSender.Model
{
    class SmtpSender
    {
        public SmtpClient Client { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


        public SmtpSender()
        {
            Client = new SmtpClient("smtp.gmail.com", 587);
            Client.Credentials = new NetworkCredential("pirozhok1985", "xxmbemcbbyffhbps");
            Client.EnableSsl = true;
        }

        public void Send(string from, string to, string subject, string body)
        {
            this.Client.Send("pirozhok1985@gmail.com", "vic1985@inbox.ru", "test subject", "Hello! World!");
        }
    }
}
