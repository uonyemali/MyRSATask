Imports System.IO
Imports System.Threading.Tasks

Public Interface ICSVService
    Function ParseCsv(csvStream As Stream) As Task(Of List(Of LocationViewModel))
    Function IsFileSizeWithinLimit(fileSize As Long) As Boolean
    Function IsFileExtensionValid(fileName As String) As Boolean
End Interface