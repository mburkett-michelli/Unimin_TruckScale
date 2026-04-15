Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Dim SetupConnectionString As String

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim SetupTableAdapter As New SetupDataSetTableAdapters.SetupTableAdapter
            Dim Tbl As New SetupDataSet.SetupDataTable

            SetupConnectionString = SetupTableAdapter.Connection.DataSource
            Tbl = SetupTableAdapter.GetData
            If Tbl.Count = 0 Then
                Call DataError()
            Else
                Dim row As SetupDataSet.SetupRow = Tbl(0)

                If row.IsDatabase_PathNull Or row.IsJournalPrinterNull Then
                    Call DataError()

                Else
                    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Chr(34) + row.Database_Path + Chr(34)
                    My.Settings.Item("Truck_ScaleConnectionString") = ConnectionString
                End If
            End If
        End Sub


        Private Sub DataError()
            MsgBox("Error With Setup File ", MsgBoxStyle.Critical, "Error...")
            My.Forms.Setup.ShowDialog()
            End

        End Sub
    End Class

End Namespace

