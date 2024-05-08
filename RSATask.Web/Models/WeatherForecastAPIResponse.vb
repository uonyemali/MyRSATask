Public Class DailyUnits
    Public Property time As String
    Public Property weather_code As String
    Public Property temperature_2m_max As String
    Public Property temperature_2m_min As String
    Public Property sunrise As String
    Public Property sunset As String
    Public Property daylight_duration As String
    Public Property sunshine_duration As String
    Public Property rain_sum As String
    Public Property showers_sum As String
    Public Property snowfall_sum As String
End Class

Public Class Daily
    Public Property time As String()
    Public Property weather_code As Double()
    Public Property temperature_2m_max As Double()
    Public Property temperature_2m_min As Double()
    Public Property sunrise As String()
    Public Property sunset As String()
    Public Property daylight_duration As Double()
    Public Property sunshine_duration As Double()
    Public Property rain_sum As Double()
    Public Property showers_sum As Double()
    Public Property snowfall_sum As Double()
End Class

Public Class WeatherForecastAPIResponse
    Public Property latitude As Double
    Public Property longitude As Double
    Public Property generationtime_ms As Double
    Public Property utc_offset_seconds As Integer
    Public Property timezone As String
    Public Property timezone_abbreviation As String
    Public Property elevation As Double

    Public Property daily_units As DailyUnits
    Public Property daily As Daily
    Public Property location_id As Double?
End Class