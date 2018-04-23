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

        public ActionResult DocumentViewerPartial() {
            XtraReport report = CreateProductsReport();
            return PartialView("_DocumentViewerPartial", report);
        }

        public ActionResult DocumentViewerExport() {
            XtraReport report = CreateProductsReport();
            return ReportViewerExtension.ExportTo(report);
        }

        static XtraReport CreateProductsReport() {
            XtraReport report = new XtraReport();

            ReportHeaderBand headerBand = new ReportHeaderBand() {
                HeightF = 80
            };
            report.Bands.Add(headerBand);

            headerBand.Controls.Add(new XRLabel() {
                Text = "Product Report",
                SizeF = new SizeF(650, 80),
                TextAlignment = TextAlignment.BottomCenter,
                Font = new Font("Arial", 36)
            });

            
            DetailBand detailBand = new DetailBand();
            report.Bands.Add(detailBand);

            XRPictureBox pbPicture = new XRPictureBox() {
                LocationF = new PointF(10,10),
                SizeF = new SizeF(190, 90),
                Sizing = ImageSizeMode.ZoomImage
            };
            detailBand.Controls.Add(pbPicture);
            pbPicture.DataBindings.Add("Image", null, "Picture");

            XRLabel lbCategoryName = new XRLabel() {
                LocationF = new PointF(200, 10),
                SizeF = new SizeF(440, 50),
                TextAlignment = TextAlignment.BottomLeft,
                Font = new Font("Arial", 24)
            };
            detailBand.Controls.Add(lbCategoryName);
            lbCategoryName.DataBindings.Add("Text", null, "CategoryName");

            XRLabel lbDescription = new XRLabel() {
                LocationF = new PointF(200, 60),
                SizeF = new SizeF(440, 40),
                TextAlignment = TextAlignment.TopLeft,
                Font = new Font("Arial", 14, FontStyle.Italic)
            };
            detailBand.Controls.Add(lbDescription);
            lbDescription.DataBindings.Add("Text", null, "Description");

            report.DataSource = Category.GetCategories();

            return report;
        }
    }
}