using MailKit.Net.Smtp;
using MimeKit;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent
{
    public class MessageService : IMessageService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0063:Use simple 'using' statement", Justification = "<Pending>")]
        public void MessageToCustomerService(ServiceMessage model)
        {
            if (model.SenderEmail != null)
            {
                var message = new MimeMessage();

                message.Sender = new MailboxAddress(model.SenderName, model.SenderEmail);
                message.To.Add(new MailboxAddress(model.RecieverName, model.RecieverEmail));
                message.Subject = model.Subject;
                message.Body = new TextPart("plain")
                {
                    Text = model.Text
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(model.SenderName, model.SenderPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }

            }

        }
        public void MessageToUser(UserMessage model)
        {
            if (model.SenderEmail != null)
            {

                var message = new MimeMessage();

                message.Sender = new MailboxAddress(model.SenderName, model.SenderEmail);
                message.To.Add(new MailboxAddress(model.RecieverName, model.RecieverEmail));
                message.Subject = model.Subject;
                message.Body = new TextPart("plain")
                {
                    Text = model.Text
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(model.SenderName, model.SenderPassword);
                    client.Send(message);
                    client.Disconnect(true);

                }

            }
        }
    }
}
