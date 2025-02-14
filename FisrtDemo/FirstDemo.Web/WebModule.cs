
using Autofac;
using FirstDemo.Web.Models;

namespace FirstDemo.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnicodeSmsSender>().As<ISmsSender>();
        }
    }
}
