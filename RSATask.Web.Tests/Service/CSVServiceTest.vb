Imports System.IO
Imports System.Threading.Tasks
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

<TestClass()>
Public Class CSVServiceTests

    Private _csvService As ICSVService

    <TestInitialize>
    Public Sub Initialize()
        _csvService = New CSVService()
    End Sub

    <TestMethod()>
    Public Async Function ParseCsv_ValidStream_ReturnsListOfLocationViewModel() As Task
        ' Arrange
        Dim csvData As String = "53.5228, -1.1312, Doncaster, UK" & vbCrLf &
                                "51.9022, -0.2026, Stevenage, UK" & vbCrLf &
                                "52.6386, -1.1317, Leicester, UK" & vbCrLf &
                                "52.9228, -1.4766, Derby, UK"
        Dim csvStream As New MemoryStream()
        Dim writer As New StreamWriter(csvStream)
        writer.Write(csvData)
        writer.Flush()
        csvStream.Position = 0

        ' Act
        Dim locations As List(Of LocationViewModel) = Await _csvService.ParseCsv(csvStream)

        ' Assert
        Assert.IsNotNull(locations)
        Assert.AreEqual(4, locations.Count)

        ' Assert specific properties of individual LocationViewModels
        ' I chose to assert the properties of the first location

        If locations.Count > 0 Then
            Dim firstLocation = locations(0)
            Assert.AreEqual(53.5228, firstLocation.Latitude)
            Assert.AreEqual(-1.1312, firstLocation.Longitude)
            Assert.AreEqual("Doncaster, UK", firstLocation.LocationName)
        End If
    End Function

    <TestMethod()>
    Public Sub IsFileSizeWithinLimit_ValidFileSize_ReturnsTrue()
        ' Arrange
        Dim fileSize As Long = 4 * 1024 * 1024 ' 4MB

        ' Act
        Dim result As Boolean = _csvService.IsFileSizeWithinLimit(fileSize)

        ' Assert
        Assert.IsTrue(result)
    End Sub

    <TestMethod()>
    Public Sub IsFileExtensionValid_ValidExtension_ReturnsTrue()
        ' Arrange
        Dim fileName As String = "test.csv"

        ' Act
        Dim result As Boolean = _csvService.IsFileExtensionValid(fileName)

        ' Assert
        Assert.IsTrue(result)
    End Sub

End Class
