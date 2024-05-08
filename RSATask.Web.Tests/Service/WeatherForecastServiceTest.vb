Imports Moq
Imports NUnit.Framework
Imports RSATask.Data
Imports RSATask.Domain.Models

<TestFixture>
Public Class WeatherForecastServiceTests
    Private _weatherForecastService As IWeatherForecastService
    Private _weatherForecastRepositoryMock As Mock(Of IRepository(Of WeatherForecast))

    <SetUp>
    Public Sub Setup()
        ' Initialize the mock repository and service
        _weatherForecastRepositoryMock = New Mock(Of IRepository(Of WeatherForecast))()
        _weatherForecastService = New WeatherForecastService(_weatherForecastRepositoryMock.Object)
    End Sub

    <Test>
    Public Sub Add_CallsRepositoryAddAndSaveChanges()
        ' Arrange
        Dim forecastToAdd As New WeatherForecast() With {.Id = 1, .search_id = "123", .location_name = "Location 1"}

        ' Act
        _weatherForecastService.Add(forecastToAdd)

        ' Assert
        _weatherForecastRepositoryMock.Verify(Sub(repo) repo.Add(forecastToAdd), Times.Once())
        _weatherForecastRepositoryMock.Verify(Sub(repo) repo.SaveChanges(), Times.Once())
    End Sub
End Class
