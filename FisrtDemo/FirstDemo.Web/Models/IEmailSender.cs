namespace FirstDemo.Web.Models
{
    public interface IEmailSender
    {
        void SendEmail(string receiverEmail, string messageBody, string subjec);
    }
}
