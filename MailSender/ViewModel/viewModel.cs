using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Model;

namespace MailSender.ViewModel
{
    class viewModel
    {
        public SmtpSender MailSender { get; set }

        public viewModel()
        {
            MailSender = new SmtpSender();
        }
    }
}
