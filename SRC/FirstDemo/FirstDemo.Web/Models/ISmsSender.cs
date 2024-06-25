namespace FirstDemo.Web.Models
{
    public interface  ISmsSender
    {
        void SendSml(string mobile, string message);
        
    }
}
