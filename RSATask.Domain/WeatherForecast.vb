Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models
    Public Class WeatherForecast
        <Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property Id As Long
        Public Property latitude As Double
        Public Property longitude As Double
        Public Property sunrise As String
        Public Property sunset As String
        Public Property location_name As String
        Public Property search_id As String
        Public Property min_temperature As String
        Public Property max_temperature As String
    End Class
End Namespace