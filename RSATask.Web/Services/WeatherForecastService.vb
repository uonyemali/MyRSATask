
Imports RSATask.Data
Imports RSATask.Domain.Models

Public Class WeatherForecastService
    Implements IWeatherForecastService

    Private ReadOnly _weatherForecastRepository As IRepository(Of WeatherForecast)

    Public Sub New(weatherForecastRepository As IRepository(Of WeatherForecast))
        _weatherForecastRepository = weatherForecastRepository
    End Sub

    Public Function GetAll() As IEnumerable(Of WeatherForecast) Implements IWeatherForecastService.GetAll
        Dim forecasts = _weatherForecastRepository.GetAll()
        Return forecasts
    End Function

    Public Function GetBySearchId(search_Id As String) As IEnumerable(Of WeatherForecast) Implements IWeatherForecastService.GetBySearchId
        Dim forecasts = _weatherForecastRepository.GetAll().Where(Function(x) x.search_id = search_Id)
        Return forecasts
    End Function

    Public Sub Add(forecast As WeatherForecast) Implements IWeatherForecastService.Add
        _weatherForecastRepository.Add(forecast)
        _weatherForecastRepository.SaveChanges()
    End Sub
End Class

