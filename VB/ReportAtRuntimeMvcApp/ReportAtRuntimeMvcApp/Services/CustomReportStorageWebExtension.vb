Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.ServiceModel
Imports DevExpress.XtraReports.Web.Extensions
Imports DevExpress.XtraReports.UI
Imports ReportAtRuntimeMvcApp.PredefinedReports

Namespace Services
    Public Class CustomReportStorageWebExtension
        Inherits DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension

        Private ReadOnly reportDirectory As String
        Private Const FileExtension As String = ".repx"
        Public Sub New(ByVal reportDirectory As String)
            If Not Directory.Exists(reportDirectory) Then
                Directory.CreateDirectory(reportDirectory)
            End If
            Me.reportDirectory = reportDirectory
        End Sub

        Private Function IsWithinReportsFolder(ByVal url As String, ByVal folder As String) As Boolean
            Dim rootDirectory = New DirectoryInfo(folder)
            Dim fileInfo = New FileInfo(Path.Combine(folder, url))
            Return fileInfo.Directory.FullName.ToLower().StartsWith(rootDirectory.FullName.ToLower())
        End Function

        Public Overrides Function CanSetData(ByVal url As String) As Boolean
            ' Determines whether a report with the specified URL can be saved.
            ' Add custom logic that returns **false** for reports that should be read-only.
            ' Return **true** if no valdation is required.
            ' This method is called only for valid URLs (if the **IsValidUrl** method returns **true**).

            Return True
        End Function

        Public Overrides Function IsValidUrl(ByVal url As String) As Boolean
            ' Determines whether the URL passed to the current report storage is valid.
            ' Implement your own logic to prohibit URLs that contain spaces or other specific characters.
            ' Return **true** if no validation is required.

            Return Path.GetFileName(url) = url
        End Function

        Public Overrides Function GetData(ByVal url As String) As Byte()
            ' Uses a specified URL to return report layout data stored within a report storage medium.
            ' This method is called if the **IsValidUrl** method returns **true**.
            ' You can use the **GetData** method to process report parameters sent from the client
            ' if the parameters are included in the report URL's query string.
            Try
                If Directory.EnumerateFiles(reportDirectory).Select(AddressOf Path.GetFileNameWithoutExtension).Contains(url) Then
                    Return File.ReadAllBytes(Path.Combine(reportDirectory, url & FileExtension))
                End If
                If ReportsFactory.Reports.ContainsKey(url) Then
                    Using ms As New MemoryStream()
                        ReportsFactory.Reports(url)().SaveLayoutToXml(ms)
                        Return ms.ToArray()
                    End Using
                End If
            Catch e1 As Exception
                Throw New FaultException(new FaultReason("Could not get report data."), new FaultCode("Server"), "GetData")
            End Try
            Throw New FaultException(New FaultReason(String.Format("Could not find report '{0}'.", url)), New FaultCode("Server"), "GetData")
        End Function

        Public Overrides Function GetUrls() As Dictionary(Of String, String)
            ' Returns a dictionary that contains the report names (URLs) and display names. 
            ' The Report Designer uses this method to populate the Open Report and Save Report dialogs.

            Return Directory.GetFiles(reportDirectory, "*" & FileExtension).Select(AddressOf Path.GetFileNameWithoutExtension).Concat(ReportsFactory.Reports.Select(Function(x) x.Key)).ToDictionary(Function(x) x)
        End Function

        Public Overrides Sub SetData(ByVal report As XtraReport, ByVal url As String)
            ' Saves the specified report to the report storage with the specified name
            ' (saves existing reports only). 
            If Not IsWithinReportsFolder(url, reportDirectory) Then Throw New FaultException(New FaultReason("Invalid report name."), New FaultCode("Server"), "GetData")
            report.SaveLayoutToXml(Path.Combine(reportDirectory, url & FileExtension))
        End Sub

        Public Overrides Function SetNewData(ByVal report As XtraReport, ByVal defaultUrl As String) As String
            ' Allows you to validate and correct the specified name (URL).
            ' This method also allows you to return the resulting name (URL),
            ' and to save your report to a storage. The method is called only for new reports.
            SetData(report, defaultUrl)
            Return defaultUrl
        End Function
    End Class
End Namespace
