Imports System
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing
Imports DevExpress.Web.Mvc
Imports ReportAtRuntimeMvcApp.Services
Imports DevExpress.XtraReports.Services

Namespace ReportAtRuntimeMvcApp

    ' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    ' visit http://go.microsoft.com/?LinkId=9394801
    Public Class MvcApplication
        Inherits HttpApplication

        Protected Sub Application_Start()
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions
            DevExpress.XtraReports.Web.WebDocumentViewer.Native.WebDocumentViewerBootstrapper.SessionState = SessionState.SessionStateBehavior.Default
            DevExpress.XtraReports.Web.QueryBuilder.Native.QueryBuilderBootstrapper.SessionState = SessionState.SessionStateBehavior.Default
            DevExpress.XtraReports.Web.ReportDesigner.Native.ReportDesignerBootstrapper.SessionState = SessionState.SessionStateBehavior.Default
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(New CustomReportStorageWebExtension(Server.MapPath("/Reports")))
            DevExpress.XtraReports.Web.WebDocumentViewer.DefaultWebDocumentViewerContainer.Register(Of IReportProvider, CustomReportProvider)()
            DevExpress.XtraReports.Web.ReportDesigner.DefaultReportDesignerContainer.Register(Of IReportProvider, CustomReportProvider)()
            Net.ServicePointManager.SecurityProtocol = Net.ServicePointManager.SecurityProtocol Or Net.SecurityProtocolType.Tls12
            Call DevExpress.XtraReports.Web.ASPxReportDesigner.StaticInitialize()
            DevExpress.XtraReports.Web.ClientControls.LoggerService.Initialize(Sub(ex, message) System.Diagnostics.Debug.WriteLine("[{0}]: Exception occurred. Message: '{1}'. Exception Details:" & Microsoft.VisualBasic.Constants.vbCrLf & "{2}", Date.Now, message, ex))
            Call AreaRegistration.RegisterAllAreas()
            Call GlobalConfiguration.Configure(New Action(Of HttpConfiguration)(AddressOf Register))
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            RouteConfig.RegisterRoutes(RouteTable.Routes)
            ModelBinders.Binders.DefaultBinder = New DevExpressEditorsBinder()
            AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error
        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim exception As Exception = HttpContext.Current.Server.GetLastError()
        'TODO: Handle Exception
        End Sub
    End Class
End Namespace
