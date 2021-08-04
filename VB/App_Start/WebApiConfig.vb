Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http

Namespace E4714.App_Start
	Public Module WebApiConfig
		Public Sub Register(ByVal config As HttpConfiguration)
			config.Routes.MapHttpRoute(name:= "DefaultApi", routeTemplate:= "api/{controller}/{id}", defaults:= New With {Key .id = RouteParameter.Optional})
		End Sub
	End Module
End Namespace
