Imports System.Threading.Tasks
Imports RSATask.Domain.Models

Public Interface IHTTPService
    Function GetForecast(locations As List(Of LocationViewModel)) As Task(Of String)

End Interface