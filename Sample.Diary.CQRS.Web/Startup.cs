using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sample.Diary.CQRS.Web.Startup))]
namespace Sample.Diary.CQRS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
