using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmStore.Startup))]
namespace FilmStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
