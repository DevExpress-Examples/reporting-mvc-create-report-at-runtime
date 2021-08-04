using DevExpress.Web.Mvc;
using DevExpress.XtraReports.Services;
using E4714.App_Start;
using E4714.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace E4714
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DevExpress.XtraReports.Web.WebDocumentViewer.DefaultWebDocumentViewerContainer.Register<IReportProvider, CustomReportProvider>();
            DevExpress.XtraReports.Web.WebDocumentViewer.Native.WebDocumentViewerBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.Default;

            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
            MVCxWebDocumentViewer.StaticInitialize();

            DevExpress.XtraReports.Web.ClientControls.LoggerService.Initialize((ex, message) => System.Diagnostics.Debug.WriteLine("[{0}]: Exception occurred. Message: '{1}'. Exception Details:\r\n{2}", DateTime.Now, message, ex));
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();

        }
    }
}
