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
        public string From { get; set; }
        public string To { get; set; }


        public SmtpSender()
        {
            Client = new SmtpClient();
            Client.Host = "smtp.gmail.com";
            Client.Port = 587;
            Client.Credentials = new NetworkCredential("pirozhok1985", "xxmbemcbbyffhbps");
            Client.EnableSsl = true;
            From = "pirozhok1985@gmail.com";
            To = "vic1985@inbox.ru";
            Subject = "test subject";
            Body = "Hello! World!";
        }

        public void Send()
        {
            this.Client.Send(From, To, Subject, Body);
        }
    }
}
