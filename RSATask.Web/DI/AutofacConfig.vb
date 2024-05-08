Imports System.Data.Entity
Imports System.Reflection
Imports System.Web.Mvc
Imports Autofac
Imports Autofac.Integration.Mvc
Imports RSATask.Data
Imports RSATask.Domain.Models

Public Module AutofacConfig
    Public Sub RegisterDependencies()
        Dim builder As New ContainerBuilder()

        ' Register your services with Autofac
        builder.RegisterType(Of WeatherForecastService).As(Of IWeatherForecastService)()
        builder.RegisterType(Of CSVService).As(Of ICSVService)()
        builder.RegisterType(Of HTTPService).As(Of IHTTPService)()


        builder.RegisterType(Of WeatherForecasterContext)().As(Of DbContext)()
        builder.RegisterGeneric(GetType(Repository(Of ))).As(GetType(IRepository(Of )))

        ' Register controllers in MVC project
        builder.RegisterControllers(Assembly.GetExecutingAssembly())
        builder.RegisterType(Of WeatherForecasterContext)().AsSelf().InstancePerLifetimeScope()

        ' Register Repository<WeatherForecast> with Autofac
        builder.Register(Function(c As IComponentContext) New Repository(Of WeatherForecast)(c.Resolve(Of WeatherForecasterContext))) _
               .As(Of IRepository(Of WeatherForecast))() _
               .InstancePerLifetimeScope()

        ' Build the Autofac container
        Dim container = builder.Build()

        ' Set Autofac as the dependency resolver for MVC
        DependencyResolver.SetResolver(New AutofacDependencyResolver(container))

    End Sub
End Module
