using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Drawing;
using DevExpress.XtraPrinting;

namespace E4714.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}
