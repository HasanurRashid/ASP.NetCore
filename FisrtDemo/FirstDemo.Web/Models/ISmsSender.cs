namespace FirstDemo.Web.Models
{
    public interface ISmsSender
    {
        void SendSms(string mobile, string message);
    }
}
