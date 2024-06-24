namespace FirstDemo.Web.Models
{
    public interface IEmailSender
    {
        public void SendEmail(string receiverEmail, string subject, string body);
    }
}
