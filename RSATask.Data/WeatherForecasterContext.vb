Imports System.Data.Entity
Imports RSATask.Domain.Models

Public Class WeatherForecasterContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("Name=WeatherForecasterContext")
    End Sub

    Public Property Forecasts As DbSet(Of WeatherForecast)
End Class
