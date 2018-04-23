Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DevExpress.XtraReports.UI
Imports System.Data
Imports System.Drawing
Imports DevExpress.XtraPrinting

Namespace E4714.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function DocumentViewerPartial() As ActionResult
			Dim report As XtraReport = CreateProductsReport()
			Return PartialView("_DocumentViewerPartial", report)
		End Function

		Public Function DocumentViewerExport() As ActionResult
			Dim report As XtraReport = CreateProductsReport()
			Return ReportViewerExtension.ExportTo(report)
		End Function

		Private Shared Function CreateProductsReport() As XtraReport
			Dim report As New XtraReport()

			Dim headerBand As New ReportHeaderBand() With {.HeightF = 80}
			report.Bands.Add(headerBand)

			headerBand.Controls.Add(New XRLabel() With {.Text = "Product Report", .SizeF = New SizeF(650, 80), .TextAlignment = TextAlignment.BottomCenter, .Font = New Font("Arial", 36)})


			Dim detailBand As New DetailBand()
			report.Bands.Add(detailBand)

			Dim pbPicture As New XRPictureBox() With {.LocationF = New PointF(10,10), .SizeF = New SizeF(190, 90), .Sizing = ImageSizeMode.ZoomImage}
			detailBand.Controls.Add(pbPicture)
			pbPicture.DataBindings.Add("Image", Nothing, "Picture")

			Dim lbCategoryName As New XRLabel() With {.LocationF = New PointF(200, 10), .SizeF = New SizeF(440, 50), .TextAlignment = TextAlignment.BottomLeft, .Font = New Font("Arial", 24)}
			detailBand.Controls.Add(lbCategoryName)
			lbCategoryName.DataBindings.Add("Text", Nothing, "CategoryName")

			Dim lbDescription As New XRLabel() With {.LocationF = New PointF(200, 60), .SizeF = New SizeF(440, 40), .TextAlignment = TextAlignment.TopLeft, .Font = New Font("Arial", 14, FontStyle.Italic)}
			detailBand.Controls.Add(lbDescription)
			lbDescription.DataBindings.Add("Text", Nothing, "Description")

			report.DataSource = Category.GetCategories()

			Return report
		End Function
	End Class
End Namespace