using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalendarAppointment.Startup))]
namespace CalendarAppointment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
