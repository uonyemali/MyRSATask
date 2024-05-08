Imports Newtonsoft.Json
Imports System.IO
Imports System.Threading.Tasks

Public Class CSVService
    Implements ICSVService

    Public Async Function ParseCsv(csvStream As Stream) As Task(Of List(Of LocationViewModel)) Implements ICSVService.ParseCsv
        ' Create a list to store the parsed location data
        Dim locations As New List(Of LocationViewModel)()

        Try
            ' Read the CSV stream line by line
            Using reader As New StreamReader(csvStream)
                While Not reader.EndOfStream
                    ' Read each line from the CSV file
                    Dim line As String = Await reader.ReadLineAsync()

                    ' Split the line into parts using comma as the delimiter
                    Dim parts As String() = line.Split(","c)

                    ' If the line contains three parts (latitude, longitude, location name)
                    If parts.Length = 4 Or parts.Length = 3 Then
                        ' Try parsing latitude and longitude as doubles
                        Dim latitude As Double
                        Dim longitude As Double
                        If Double.TryParse(parts(0).Trim(), latitude) AndAlso
                        Double.TryParse(parts(1).Trim(), longitude) Then

                            ' Extract the location name and remove the country code if present
                            Dim locationName As String = $"{parts(2).Trim()}, {parts(3).Trim()}".ToString()

                            ' Create a new LocationViewModel object and add it to the list
                            locations.Add(New LocationViewModel With {
                            .Latitude = latitude,
                            .Longitude = longitude,
                            .LocationName = locationName
                        })
                        End If
                    End If
                End While
            End Using
        Catch ex As Exception
            ' Handle any exceptions
            Console.WriteLine("An error occurred while parsing CSV: " & ex.Message)
        End Try

        ' Return the list of parsed locations
        Return locations
    End Function

    Public Function IsFileSizeWithinLimit(fileSize As Long) As Boolean Implements ICSVService.IsFileSizeWithinLimit
        Dim maxFileSizeBytes As Long = 5 * 1024 * 1024 ' 5MB in bytes
        Return fileSize <= maxFileSizeBytes
    End Function

    Public Function IsFileExtensionValid(fileName As String) As Boolean Implements ICSVService.IsFileExtensionValid
        Dim validExtensions As String() = {".csv"}
        Dim extension As String = Path.GetExtension(fileName).ToLower()
        Return validExtensions.Contains(extension)
    End Function

End Class
