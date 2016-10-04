using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HansonFoods.Startup))]
namespace HansonFoods
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
