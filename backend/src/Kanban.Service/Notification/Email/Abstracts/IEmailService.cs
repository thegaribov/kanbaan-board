using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Notification.Email.Abstracts
{
    public interface IEmailService
    {
        public class Message
        {
            public List<MailboxAddress> Receivers { get; set; } = new List<MailboxAddress>();
            public string Subject { get; set; }
            public string Body { get; set; }

            public Message(string subject, string body, List<string> receivers)
            {
                Subject = subject;
                Body = body;
                Receivers.AddRange(receivers?.Select(recipent => new MailboxAddress(string.Empty, recipent)));
            }
        }

        Task<bool> SendAsync(Message message);
        Task<bool> SendAsync(string subject, string body, params string[] receivers)
        {
            var message = new Message(subject, body, receivers.ToList());

            return SendAsync(message);
        }

        void SendInBackground(Message message);
        void SendInBackground(string subject, string body, params string[] receivers)
        {
            var message = new Message(subject, body, receivers.ToList());

            SendInBackground(message);
        }
    }
}
