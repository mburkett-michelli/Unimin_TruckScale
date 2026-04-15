Imports System.Windows.Forms
Imports System.Drawing.Printing
Public Class Setup

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Me.Validate()
            Me.SetupBindingSource.EndEdit()
            Me.SetupTableAdapter.Update(Me.SetupDataSet.Setup)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SetupBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.SetupBindingSource.EndEdit()
        Me.SetupTableAdapter.Update(Me.SetupDataSet.Setup)

    End Sub

    Private Sub Setup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SetupDataSet.Setup' table. You can move, or remove it, as needed.
        Me.SetupTableAdapter.Fill(Me.SetupDataSet.Setup)
        If Me.SetupBindingSource.Count = 0 Then
            Me.SetupBindingSource.AddNew()
        End If


        Dim i As Integer
        Dim pkInstalledPrinters As String

        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            JournalPrinterComboBox.Items.Add(pkInstalledPrinters)

        Next


    End Sub

    Private Sub SetupBindingNavigator_RefreshItems(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.OpenFileDialog1.Filter = "access files (*.mdb)|*.mdb"
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Database_PathTextBox.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub
End Class
