using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stratiteq.DeployVersionInfo.Startup))]
namespace Stratiteq.DeployVersionInfo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);


        }        
    }
}
