Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Net.Http
Imports Moq
Imports System.Threading.Tasks
Imports System.Net
Imports Newtonsoft.Json

<TestClass()>
Public Class HTTPServiceTests

    Private ReadOnly _httpClientMock As Mock(Of HttpClient)
    Private ReadOnly _weatherForecastServiceMock As Mock(Of IWeatherForecastService)
    Private ReadOnly _httpService As HTTPService

    Public Sub New()
        _httpClientMock = New Mock(Of HttpClient)()
        _weatherForecastServiceMock = New Mock(Of IWeatherForecastService)()
        _httpService = New HTTPService(_weatherForecastServiceMock.Object)
    End Sub

    <TestMethod()>
    Public Async Function GetForecast_NullLocations_ReturnsEmptySearchId() As Task
        ' Arrange
        Dim locations As List(Of LocationViewModel) = Nothing

        ' Act
        Dim searchId As String = Await _httpService.GetForecast(locations)

        ' Assert
        Assert.IsTrue(String.IsNullOrEmpty(searchId))
    End Function

    ' Integration Test
    <TestMethod()>
    Public Async Function GetForecast_IntegrationTest_SuccessfulResponse_ReturnsSearchId() As Task
        ' Arrange
        Dim apiUrl As String = "https://api.open-meteo.com/v1/forecast?daily=weather_code,temperature_2m_max,temperature_2m_min,sunrise,sunset,daylight_duration,sunshine_duration,rain_sum,showers_sum,snowfall_sum&forecast_days=3"
        Dim locations As New List(Of LocationViewModel)()

        ' Act
        Dim searchId As String = Await _httpService.GetForecast(locations)

        ' Assert
        Assert.IsNotNull(searchId)
    End Function

End Class
