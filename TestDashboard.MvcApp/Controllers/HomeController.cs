using System.Web.Mvc;

namespace TestDashboard.MvcApp.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}