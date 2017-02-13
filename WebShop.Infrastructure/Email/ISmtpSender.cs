namespace WebShop.Infrastructure.Email
{
    public interface ISmtpSender
    {
        bool AsyncSend { get; set; }
        string Hostname { get; }
        string Password { get; set; }
        int Timeout { get; set; }
        string UserName { get; set; }
        void Dispose();
        void Send(Message message);
        void Send(string from, string to, string subject, string messageText);
        void Send(string from, string to, string cc, string bcc, string subject, string messageText);
    }
}