using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvorionTest.Startup))]
namespace AvorionTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
