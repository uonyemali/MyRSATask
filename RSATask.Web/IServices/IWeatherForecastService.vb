
Imports RSATask.Domain.Models

Public Interface IWeatherForecastService
    Function GetAll() As IEnumerable(Of WeatherForecast)
    Sub Add(forecast As WeatherForecast)
    Function GetBySearchId(search_Id As String) As IEnumerable(Of WeatherForecast)

End Interface