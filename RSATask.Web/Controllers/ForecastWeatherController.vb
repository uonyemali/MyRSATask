Imports System.IO
Imports System.Threading.Tasks
Imports RSATask.Domain.Models

Namespace Controllers
    Public Class ForecastWeatherController
        Inherits Controller

        Private ReadOnly _weatherForecastService As IWeatherForecastService
        Private ReadOnly _csvService As ICSVService
        Private ReadOnly _httpService As IHTTPService

        Public Sub New(weatherForecastService As IWeatherForecastService,
                       csvService As ICSVService, httpService As IHTTPService)

            _weatherForecastService = weatherForecastService
            _csvService = csvService
            _httpService = httpService
        End Sub

        ' GET: WeatherForecast/List
        Function List(Optional search_id As String = Nothing) As ActionResult
            Dim forecasts As IEnumerable(Of WeatherForecast)

            If Not String.IsNullOrEmpty(search_id) Then
                forecasts = _weatherForecastService.GetBySearchId(search_id)
            Else
                forecasts = _weatherForecastService.GetAll()
            End If

            Return View(forecasts)

        End Function
        ' GET: ForecastWeather/Upload
        Function Upload() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Async Function Upload(forecastFile As HttpPostedFileBase) As Task(Of ActionResult)
            If forecastFile IsNot Nothing AndAlso forecastFile.ContentLength > 0 Then
                Try
                    ' Check if the file size is within the allowed limit (5MB)
                    If Not _csvService.IsFileSizeWithinLimit(forecastFile.ContentLength) Then
                        ViewData("ErrorMessage") = "File size exceeds the maximum allowed limit (5MB)."
                        Return View()
                    End If

                    If _csvService.IsFileExtensionValid(forecastFile.FileName) Then
                        Dim locations As List(Of LocationViewModel) = Await _csvService.ParseCsv(forecastFile.InputStream)

                        If locations.Any() Then
                            Dim searchId = Await _httpService.GetForecast(locations)
                            Return RedirectToAction("List", New With {.search_id = searchId})
                        Else
                            ViewData("ErrorMessage") = "No valid locations found in the CSV file."
                        End If
                    Else
                        ViewData("ErrorMessage") = "Only CSV files (.csv) are allowed."
                    End If

                Catch ex As Exception
                    ' Logger.LogError(ex, "An error occurred during file upload.") --
                    ViewData("ErrorMessage") = "An unexpected error occurred. Please try again later."
                End Try
            Else
                ViewData("ErrorMessage") = "Please select a file."
            End If
            Return View()
        End Function

    End Class
End Namespace
