Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports RSATask.Domain.Models

Public Class HTTPService
    Implements IHTTPService

    Private ReadOnly _httpClient As HttpClient
    Private ReadOnly _weatherForecastService As IWeatherForecastService

    Public Sub New(weatherForecastService As IWeatherForecastService)
        _httpClient = New HttpClient()
        _weatherForecastService = weatherForecastService
    End Sub

    Public Async Function GetForecast(locations As List(Of LocationViewModel)) As Task(Of String) Implements IHTTPService.GetForecast
        Dim searchId As String = String.Empty

        Try
            Dim apiUrl As String = ConstructApiUrl(locations)
            Dim forecastData As List(Of WeatherForecastAPIResponse) = Await FetchForecastData(apiUrl)

            If forecastData IsNot Nothing Then
                searchId = Guid.NewGuid().ToString().Replace("-", "")
                ' Loop through the forecast data and process each entry
                For index As Integer = 0 To forecastData.Count - 1
                    Dim entry As WeatherForecastAPIResponse = forecastData(index)

                    ' Get the corresponding location for the current entry
                    Dim location As LocationViewModel = If(index < locations.Count, locations(index), Nothing)

                    ' Get the location name or set it to "Unknown" if not found
                    Dim locationName As String = If(location IsNot Nothing, location.LocationName, "Unknown")

                    ' Map the API response to a WeatherForecast object and add it to the service
                    Dim forecast As WeatherForecast = MapToWeatherForecast(entry, locationName, searchId)
                    _weatherForecastService.Add(forecast)
                Next
            End If

        Catch ex As Exception
            Console.WriteLine("An error occurred: " & ex.Message)
        End Try

        Return searchId
    End Function

    Private Async Function FetchForecastData(apiUrl As String) As Task(Of List(Of WeatherForecastAPIResponse))
        Dim response As HttpResponseMessage = Await _httpClient.GetAsync(apiUrl)
        If response.IsSuccessStatusCode Then
            Dim json As String = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of List(Of WeatherForecastAPIResponse))(json)
        Else
            Console.WriteLine("Error fetching weather data: " & response.ReasonPhrase)
            Return Nothing
        End If
    End Function

    Private Function ConstructApiUrl(locations As List(Of LocationViewModel)) As String
        Dim apiUrl As String = "https://api.open-meteo.com/v1/forecast?daily=weather_code,temperature_2m_max,temperature_2m_min,sunrise,sunset,daylight_duration,sunshine_duration,rain_sum,showers_sum,snowfall_sum&forecast_days=3"
        Dim latitudes As String = String.Join(",", locations.Select(Function(loc) loc.Latitude))
        Dim longitudes As String = String.Join(",", locations.Select(Function(loc) loc.Longitude))
        apiUrl &= $"&latitude={latitudes}&longitude={longitudes}"
        Return apiUrl
    End Function

    Private Function MapToWeatherForecast(entry As WeatherForecastAPIResponse, locationName As String, searchId As String) As WeatherForecast
        Return New WeatherForecast() With {
            .longitude = entry.longitude,
            .latitude = entry.latitude,
            .search_id = searchId,
            .location_name = locationName.Replace("""", ""),
            .sunrise = String.Join(", ", entry.daily.sunrise),
            .sunset = String.Join(", ", entry.daily.sunset),
            .min_temperature = String.Join(", ", entry.daily.temperature_2m_min),
            .max_temperature = String.Join(", ", entry.daily.temperature_2m_max)
        }
    End Function

End Class
