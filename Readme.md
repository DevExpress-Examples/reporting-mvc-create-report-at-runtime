<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128596431/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4714)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [ReportProvider.cs](./CS/Services/ReportProvider.cs) (VB: [ReportProvider.vb](./VB/Services/ReportProvider.vb))

# How to dynamically generate a report in an ASP.NET MVC application

This example illustrates how to create a DevExpress Report in code and preview it on a web page in an ASP.NET MVC application.

## Create a report at runtime
To create a report at runtime, create a report instance and add <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument2590">report bands</a> and <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument2605"> report controls</a>. Specify [expression bindings](https://docs.devexpress.com/XtraReports/1180/detailed-guide-to-devexpress-reporting/use-report-controls/bind-report-controls-to-data/specify-a-control-s-binding-expression) for report controls. [Bind the report to data](https://docs.devexpress.com/XtraReports/15034/detailed-guide-to-devexpress-reporting/bind-reports-to-data).

## Preview a report of a web page
Use the [Web Document Viewer]() to preview a report on a web page. In this example, the viewer uses [IReportProvider](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.Services.IReportProvider) to load a report by its name. The name of a report is passed to the [Bind](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.WebDocumentViewerExtension.Bind.overloads) method of [WebDocumentViewerExtension](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.WebDocumentViewerExtension). You can also bind the viewer to a report instance, a model, or the report associated with the specified CachedReportSourceWeb object. For more information, see [WebDocumentViewerExtension.Bind method overloads](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.WebDocumentViewerExtension.Bind.overloads).  

## See also
* [ASP.NET MVC Reporting](https://docs.devexpress.com/XtraReports/400247/web-reporting/asp-net-mvc-reporting?p=netframework)

