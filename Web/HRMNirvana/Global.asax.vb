Imports System.Net
Imports System.Security.Claims
Imports System.Web.Helpers
Imports System.Web.Hosting
Imports System.Web.Http
Imports System.Web.Optimization
Imports AutoMapper
Imports risersoft.API.GSTN
Imports risersoft.app.mxform.gst
Imports risersoft.shared.web
Imports risersoft.shared.web.mvc
Imports risersoft.web.mvc.gst.Controllers
Imports risersoft.web.mvc.hrm.Controllers

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        Dim oApp = New clsMvcWebApp(New clsExtendWebAppHRM)
        'myFuncs2.InitializeMapper()
        GlobalWeb.myWebApp = oApp
        oApp.fncVirutalPathProvider = Function()
                                          Dim provider = New EmbeddedVirtualPathProvider()
                                          provider.AddTypeAssembly(GetType(frmCampusAreaController).Assembly)
                                          Return provider
                                      End Function
        HostingEnvironment.RegisterVirtualPathProvider(oApp.fncVirutalPathProvider())
        ControllerBuilder.Current.SetControllerFactory(GetType(MyControllerFactory))
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier
        Dim razorEngine = ViewEngines.Engines.OfType(Of RazorViewEngine)().FirstOrDefault()
        razorEngine.ViewLocationFormats = razorEngine.ViewLocationFormats.Concat(New String() {"~/Views/Forms/{0}.cshtml", "~/Views/Forms/{0}.vbhtml"}).ToArray()
        razorEngine.PartialViewLocationFormats = razorEngine.PartialViewLocationFormats.Concat(New String() {"~/Views/Forms/{0}.cshtml", "~/Views/Forms/{0}.vbhtml"}).ToArray()

    End Sub
End Class
