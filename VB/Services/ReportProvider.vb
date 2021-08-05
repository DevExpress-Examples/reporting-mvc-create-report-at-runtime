Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Web
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.Services

Namespace E4714.Services
	Public Class CustomReportProvider
		Implements DevExpress.XtraReports.Services.IReportProvider

		Public Function GetReport(ByVal id As String, ByVal context As ReportProviderContext) As XtraReport
			If String.IsNullOrEmpty(id) Then
				Return Nothing
			End If
			Select Case id
				Case "TestReport"
					Return CreateProductsReport()
			End Select
			Return New XtraReport()
		End Function
		Private Function CreateProductsReport() As XtraReport
			Dim report As New XtraReport()
			Dim headerBand As New ReportHeaderBand() With {.HeightF = 80}
			report.Bands.Add(headerBand)
			headerBand.Controls.Add(New XRLabel() With {
				.Text = "Categories Report",
				.SizeF = New SizeF(650, 80),
				.TextAlignment = TextAlignment.BottomCenter,
				.Font = New Font("Arial", 36)
			})
			Dim detailBand As New DetailBand()
			report.Bands.Add(detailBand)
			Dim pbPicture As New XRPictureBox() With {
				.LocationF = New PointF(10, 10),
				.SizeF = New SizeF(190, 90),
				.Sizing = ImageSizeMode.ZoomImage
			}
			pbPicture.ExpressionBindings.Add(New ExpressionBinding("Image", "Picture"))
			detailBand.Controls.Add(pbPicture)
			Dim lbCategoryName As New XRLabel() With {
				.LocationF = New PointF(200, 10),
				.SizeF = New SizeF(440, 50),
				.TextAlignment = TextAlignment.BottomLeft,
				.Font = New Font("Arial", 24)
			}
			lbCategoryName.ExpressionBindings.Add(New ExpressionBinding("Text", "CategoryName"))
			detailBand.Controls.Add(lbCategoryName)
			Dim lbDescription As New XRLabel() With {
				.LocationF = New PointF(200, 60),
				.SizeF = New SizeF(440, 40),
				.TextAlignment = TextAlignment.TopLeft,
				.Font = New Font("Arial", 14, FontStyle.Italic)
			}
			lbDescription.ExpressionBindings.Add(New ExpressionBinding("Text", "Description"))
			detailBand.Controls.Add(lbDescription)
			report.DataSource = CreateDataSource()
			report.DataMember = "Categories"
			Return report
		End Function

		Private Function CreateDataSource() As Object
			Dim dbFilePath As String = HttpContext.Current.Server.MapPath("/App_Data/nwind.mdb")
			Dim connectionParameters = New Access97ConnectionParameters(dbFilePath, "", "")
			Dim ds = New SqlDataSource(connectionParameters)
			Dim query As SelectQuery = SelectQueryFluentBuilder.AddTable("Categories").SelectAllColumns().Build("Categories")
			ds.Queries.Add(query)
			ds.Fill()
			Return ds
		End Function
	End Class
End Namespace
