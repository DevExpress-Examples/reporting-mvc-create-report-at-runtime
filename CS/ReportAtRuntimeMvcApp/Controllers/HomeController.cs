using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportAtRuntimeMvcApp.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Designer() {
            Models.ReportDesignerModel model = new Models.ReportDesignerModel();
            return View(model);
        }

        public ActionResult Viewer() {
            return View();
        }
    }
}
