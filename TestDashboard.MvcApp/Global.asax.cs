using System.Web.Mvc;
using System.Web.Routing;

namespace TestDashboard.MvcApp {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            DashboardConfig.RegisterService(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
