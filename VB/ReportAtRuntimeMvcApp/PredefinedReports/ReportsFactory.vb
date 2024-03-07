Imports DevExpress.XtraReports.UI
Imports System
Imports System.Collections.Generic

Namespace ReportAtRuntimeMvcApp.PredefinedReports

    Public Module ReportsFactory

        Sub New()
            Call Reports.Add("TestReport", Function() New TestReport())
        End Sub

        Public Reports As Dictionary(Of String, Func(Of XtraReport)) = New Dictionary(Of String, Func(Of XtraReport))()
    End Module
End Namespace
