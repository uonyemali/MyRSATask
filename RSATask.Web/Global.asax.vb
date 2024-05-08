Imports System.Web.Optimization
Imports OfficeOpenXml

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AutofacConfig.RegisterDependencies() ' Call RegisterDependencies method


        ' Set the LicenseContext property for EPPlus
        OfficeOpenXml.ExcelPackage.LicenseContext = LicenseContext.NonCommercial

    End Sub
End Class
