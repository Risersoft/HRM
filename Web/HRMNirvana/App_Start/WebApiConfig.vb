Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports risersoft.shared.web
Imports System.Web.Http.Dispatcher
Imports risersoft.shared.bot

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services
        ' Web API configuration and services
        config.ParameterBindingRules.Insert(0, AddressOf MultiPostParameterBinding.CreateBindingForMarkedParameters)

        config.Services.Replace(GetType(IHttpControllerSelector), New MyHttpControllerSelector(config))

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
         name:="ValuesApi",
    routeTemplate:="api/RSValues/{id}",
    defaults:=New With {.controller = "RSValues", .id = RouteParameter.Optional}
     )

        config.Routes.MapHttpRoute(
         name:="ActionApi",
    routeTemplate:="api/{controller}/{action}/{id}",
    defaults:=New With {.id = RouteParameter.Optional}
     )


        UnityConfig.RegisterComponents(config)
    End Sub
End Module
