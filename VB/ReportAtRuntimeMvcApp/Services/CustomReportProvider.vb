Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.Services
Imports DevExpress.XtraReports.UI
Imports System.Drawing

Namespace ReportAtRuntimeMvcApp.Services

    Public Class CustomReportProvider
        Implements IReportProvider

        Public Function GetReport(ByVal id As String, ByVal context As ReportProviderContext) As XtraReport Implements IReportProvider.GetReport
            If String.IsNullOrEmpty(id) Then Return Nothing
            Select Case id
                Case "TestReport"
                    Return CreateProductsReport()
            End Select

            Return New XtraReport()
        End Function

        Private Function CreateProductsReport() As XtraReport
            Dim report As XtraReport = New XtraReport()
            Dim headerBand As ReportHeaderBand = New ReportHeaderBand() With {.HeightF = 80}
            report.Bands.Add(headerBand)
            headerBand.Controls.Add(New XRLabel() With {.Text = "Categories Report", .SizeF = New SizeF(650, 80), .TextAlignment = TextAlignment.BottomCenter, .Font = New Font("Arial", 36)})
            Dim detailBand As DetailBand = New DetailBand()
            report.Bands.Add(detailBand)
            Dim pbPicture As XRPictureBox = New XRPictureBox() With {.LocationF = New PointF(10, 10), .SizeF = New SizeF(190, 90), .Sizing = ImageSizeMode.ZoomImage}
            pbPicture.ExpressionBindings.Add(New ExpressionBinding("Image", "Picture"))
            detailBand.Controls.Add(pbPicture)
            Dim lbCategoryName As XRLabel = New XRLabel() With {.LocationF = New PointF(200, 10), .SizeF = New SizeF(440, 50), .TextAlignment = TextAlignment.BottomLeft, .Font = New Font("Arial", 24)}
            lbCategoryName.ExpressionBindings.Add(New ExpressionBinding("Text", "CategoryName"))
            detailBand.Controls.Add(lbCategoryName)
            Dim lbDescription As XRLabel = New XRLabel() With {.LocationF = New PointF(200, 60), .SizeF = New SizeF(440, 40), .TextAlignment = TextAlignment.TopLeft, .Font = New Font("Arial", 14, FontStyle.Italic)}
            lbDescription.ExpressionBindings.Add(New ExpressionBinding("Text", "Description"))
            detailBand.Controls.Add(lbDescription)
            report.DataSource = CreateDataSource()
            report.DataMember = "Categories"
            Return report
        End Function

        Private Function CreateDataSource() As Object
            Dim ds = New SqlDataSource("nwind")
            Dim query As SelectQuery = SelectQueryFluentBuilder.AddTable("Categories").SelectAllColumns().Build("Categories")
            ds.Queries.Add(query)
            ds.Fill()
            Return ds
        End Function
    End Class
End Namespace
