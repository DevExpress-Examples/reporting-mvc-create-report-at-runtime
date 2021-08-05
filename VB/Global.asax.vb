Imports DevExpress.Web.Mvc
Imports DevExpress.XtraReports.Services
Imports E4714.App_Start
Imports E4714.Services
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace E4714
    Public Class MvcApplication
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start()
            DevExpress.XtraReports.Web.WebDocumentViewer.DefaultWebDocumentViewerContainer.Register(Of IReportProvider, CustomReportProvider)()
            DevExpress.XtraReports.Web.WebDocumentViewer.Native.WebDocumentViewerBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.Default

            System.Net.ServicePointManager.SecurityProtocol = System.Net.ServicePointManager.SecurityProtocol Or System.Net.SecurityProtocolType.Tls12
            MVCxWebDocumentViewer.StaticInitialize()
            AreaRegistration.RegisterAllAreas()
            GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            RouteConfig.RegisterRoutes(RouteTable.Routes)

            ModelBinders.Binders.DefaultBinder = New DevExpress.Web.Mvc.DevExpressEditorsBinder()

        End Sub
    End Class
End Namespace
