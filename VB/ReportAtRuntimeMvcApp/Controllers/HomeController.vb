Imports System.Web.Mvc

Namespace ReportAtRuntimeMvcApp.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function Designer() As ActionResult
            Dim model As Models.ReportDesignerModel = New Models.ReportDesignerModel()
            Return View(model)
        End Function

        Public Function Viewer() As ActionResult
            Return View()
        End Function
    End Class
End Namespace
