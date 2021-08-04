using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;

namespace E4714.Services {
    public class CustomReportProvider : DevExpress.XtraReports.Services.IReportProvider {
        public XtraReport GetReport(string id, ReportProviderContext context) {
            if (string.IsNullOrEmpty(id))
                return null;
            switch (id) {
                case "TestReport":
                    return CreateProductsReport();
            }
            return new XtraReport();
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
                LocationF = new PointF(10, 10),
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
