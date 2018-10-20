﻿using PoohAPI.Logic.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PoohAPI.Logic.Common.Classes
{
    public class MailClient : IMailClient
    {
        public void SendEmail(string userEmail, string subject, string body)
        {
            if (userEmail is null || subject is null || body is null)
                return;

            // TODO: change sender email address and host
            MailMessage mail = new MailMessage("sender@test.nl", userEmail);
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "localhost";
            
            client.Send(mail);
        }
    }
}
