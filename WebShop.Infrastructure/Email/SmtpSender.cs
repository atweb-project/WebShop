using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace WebShop.Infrastructure.Email
{
    public class SmtpSender : IDisposable, ISmtpSender
    {
        private SmtpClient _smtpClient;
        private bool _asyncSend = false;
        private readonly string _hostname;
        private readonly int _port = 587;

        public SmtpSender(string hostname)
        {
            if (String.IsNullOrWhiteSpace(hostname))
                throw new ArgumentException("Check hostname .", "Hostname is not valid !!!");

            this._hostname = hostname;
            _smtpClient = new SmtpClient(hostname);
        }

        public SmtpSender(string hostname, string userName, string password)
            : this(hostname)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public String UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Password { get; set; }

        public string Hostname
        {
            get { return _hostname; }
        }

        public bool AsyncSend
        {
            get { return _asyncSend; }
            set { _asyncSend = value; }
        }

        public int Timeout
        {
            get { return _smtpClient.Timeout; }
            set { _smtpClient.Timeout = value; }
        }

        public void Send(String from, String to, String subject, String messageText)
        {
            if (from == null)
                throw new ArgumentNullException("from");
            if (to == null)
                throw new ArgumentNullException("to");
            if (subject == null)
                throw new ArgumentNullException("subject");
            if (messageText == null)
                throw new ArgumentNullException("messageText");

            Send(new Message(from, to, subject, messageText));
        }

        public void Send(String from, String to, String cc, String bcc, String subject, String messageText)
        {
            if (from == null)
                throw new ArgumentNullException("from");
            if (to == null)
                throw new ArgumentNullException("to");
            if (subject == null)
                throw new ArgumentNullException("subject");
            if (messageText == null)
                throw new ArgumentNullException("messageText");

            Send(new Message(from, to, cc, bcc, subject, messageText));
        }

        public void Send(Message message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ConfigureSender(message);

            if (_asyncSend)
            {
                MailMessage msg = CreateMailMessage(message);
                Guid msgGuid = new Guid();
                _smtpClient.SendCompleted += (s, e) => {
                    _smtpClient.Dispose();
                    msg.Dispose();
                };
                _smtpClient.SendAsync(CreateMailMessage(message), msgGuid);
            }
            else
            {
                using (MailMessage msg = CreateMailMessage(message))
                {
                    _smtpClient.Send(msg);
                }
            }
        }

        protected void ConfigureSender(Message message)
        {
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.DeliveryFormat = SmtpDeliveryFormat.International;

            // AKIAIY2BZZUWMUQEK6CQ
            // AuZ79ZbB5Ij1/hEskeNXJbdu+8FutD/AnewHhmOGEClV

            _smtpClient.Credentials = new System.Net.NetworkCredential(this.UserName, this.Password);
            //_smtpClient.Credentials = new System.Net.NetworkCredential("AKIAJ3UTPMMOVCR2VMCA", "AsWZoOnn9I0n/x/3XGWuza1l7umI4RTRwEAiUBk0UhUHO");
            _smtpClient.EnableSsl = true;
            _smtpClient.Timeout = 40000;
        }

        private static MailMessage CreateMailMessage(Message message)
        {
            MailMessage mailMessage = new MailMessage(message.From, message.To.Replace(';', ','));

            if (!String.IsNullOrEmpty(message.Cc))
            {
                mailMessage.CC.Add(message.Cc.Replace(';', ','));
            }

            if (!String.IsNullOrEmpty(message.Bcc))
            {
                mailMessage.Bcc.Add(message.Bcc.Replace(';', ','));
            }

            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;
            mailMessage.BodyEncoding = message.Encoding;
            mailMessage.IsBodyHtml = (message.Format == Format.Html);
            mailMessage.Priority = (MailPriority)Enum.Parse(typeof(MailPriority), message.Priority.ToString());

            foreach (MessageAttachment attachment in message.Attachments)
            {
                Attachment mailAttach;

                if (attachment.Stream != null)
                {
                    mailAttach = new Attachment(attachment.Stream, attachment.FileName, attachment.MediaType);
                }
                else
                {
                    mailAttach = new Attachment(attachment.FileName, attachment.MediaType);
                }

                mailMessage.Attachments.Add(mailAttach);
            }


            return mailMessage;
        }
        public void Dispose()
        {
            _smtpClient.Dispose();
        }
    }
}
