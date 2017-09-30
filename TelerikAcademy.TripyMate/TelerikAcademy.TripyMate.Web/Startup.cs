using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelerikAcademy.TripyMate.Web.Startup))]
namespace TelerikAcademy.TripyMate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
