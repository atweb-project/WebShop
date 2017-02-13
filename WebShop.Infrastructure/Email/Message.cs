using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace WebShop.Infrastructure.Email
{
    public enum AttachmentFilenameType
    {
        /// <summary>
        /// 
        /// </summary>
        Text,
        /// <summary>
        /// 
        /// </summary>
        Csv
    }

    public enum MessagePriority
    {
        Normal,
        High,
        Low
    }

    public enum Format
    {
        /// <summary>
        /// The body is composed of html content
        /// </summary>
        Html,
        /// <summary>
        /// The body is pure text
        /// </summary>
        Text
    }

    public class MessageAttachmentList : List<MessageAttachment>
    {
    }

    public class Message
    {
        private Format _format = Format.Text;
        private Encoding _encoding = Encoding.ASCII;
        private MessagePriority _priority = MessagePriority.Normal;
        private MessageAttachmentList _attachments = new MessageAttachmentList();

        public String To { get; set; }

        public String From { get; set; }

        public String Cc { get; set; }

        public String Bcc { get; set; }

        public String Body { get; set; }

        public String Subject { get; set; }

        public MailAddress ReplyTo { get; set; }

        public Message()
        {

        }

        public Message(string from, string to, string subject, string body)
        {
            this.To = to;
            this.From = from;
            this.Body = body;
            this.Subject = subject;
        }

        public Message(string from, string to, string cc, string bcc, string subject, string body)
        {
            this.To = to;
            this.Bcc = bcc;
            this.Cc = cc;
            this.From = from;
            this.Body = body;
            this.Subject = subject;
        }

        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        public Format Format
        {
            get { return _format; }
            set { _format = value; }
        }

        public MessagePriority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public MessageAttachmentList Attachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }


    }
}
