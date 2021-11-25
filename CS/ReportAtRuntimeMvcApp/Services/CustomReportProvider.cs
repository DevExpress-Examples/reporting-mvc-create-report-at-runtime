using DevExpress.DataAccess.Sql;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace ReportAtRuntimeMvcApp.Services
{
    public class CustomReportProvider : DevExpress.XtraReports.Services.IReportProvider
    {
        public XtraReport GetReport(string id, ReportProviderContext context)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            switch (id)
            {
                case "TestReport":
                    return CreateProductsReport();
            }
            return new XtraReport();
        }
        XtraReport CreateProductsReport()
        {
            XtraReport report = new XtraReport();
            ReportHeaderBand headerBand = new ReportHeaderBand()
            {
                HeightF = 80
            };
            report.Bands.Add(headerBand);
            headerBand.Controls.Add(new XRLabel()
            {
                Text = "Categories Report",
                SizeF = new SizeF(650, 80),
                TextAlignment = TextAlignment.BottomCenter,
                Font = new Font("Arial", 36)
            });
            DetailBand detailBand = new DetailBand();
            report.Bands.Add(detailBand);
            XRPictureBox pbPicture = new XRPictureBox()
            {
                LocationF = new PointF(10, 10),
                SizeF = new SizeF(190, 90),
                Sizing = ImageSizeMode.ZoomImage
            };
            pbPicture.ExpressionBindings.Add(new ExpressionBinding("Image", "Picture"));
            detailBand.Controls.Add(pbPicture);
            XRLabel lbCategoryName = new XRLabel()
            {
                LocationF = new PointF(200, 10),
                SizeF = new SizeF(440, 50),
                TextAlignment = TextAlignment.BottomLeft,
                Font = new Font("Arial", 24)
            };
            lbCategoryName.ExpressionBindings.Add(new ExpressionBinding("Text", "CategoryName"));
            detailBand.Controls.Add(lbCategoryName);
            XRLabel lbDescription = new XRLabel()
            {
                LocationF = new PointF(200, 60),
                SizeF = new SizeF(440, 40),
                TextAlignment = TextAlignment.TopLeft,
                Font = new Font("Arial", 14, FontStyle.Italic)
            };
            lbDescription.ExpressionBindings.Add(new ExpressionBinding("Text", "Description"));
            detailBand.Controls.Add(lbDescription);
            report.DataSource = CreateDataSource();
            report.DataMember = "Categories";
            return report;
        }

        private object CreateDataSource()
        {
            var ds = new SqlDataSource("nwind");
            SelectQuery query = SelectQueryFluentBuilder.AddTable("Categories")
                .SelectAllColumns()
                .Build("Categories");
            ds.Queries.Add(query);
            ds.Fill();
            return ds;
        }
    }
}
