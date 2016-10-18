using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Herzog.Web.Startup))]
namespace Herzog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
