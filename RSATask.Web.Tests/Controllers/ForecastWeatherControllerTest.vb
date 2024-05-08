Imports System.IO
Imports System.Threading.Tasks
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports RSATask.Domain.Models
Imports System.Web.Mvc
Imports RSATask.Web.Controllers
Imports System.Web

<TestClass()>
Public Class ForecastWeatherControllerTests

    Private _weatherForecastServiceMock As Mock(Of IWeatherForecastService)
    Private _csvServiceMock As Mock(Of ICSVService)
    Private _httpServiceMock As Mock(Of IHTTPService)
    Private _controller As ForecastWeatherController

    <TestInitialize>
    Public Sub Initialize()
        _weatherForecastServiceMock = New Mock(Of IWeatherForecastService)()
        _csvServiceMock = New Mock(Of ICSVService)()
        _httpServiceMock = New Mock(Of IHTTPService)()
        _controller = New ForecastWeatherController(_weatherForecastServiceMock.Object, _csvServiceMock.Object, _httpServiceMock.Object)
    End Sub

End Class
