Imports System.Windows.Forms

Public Class CheckWeight
    Public InboundId As Integer = -1
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckWeight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UpdateWeight()
        Dim InboundTableAdapter As New Truck_ScaleDataSetTableAdapters.InboundTableAdapter
        Dim Tbl As New Truck_ScaleDataSet.InboundDataTable
        If InboundId >= 0 Then
            Tbl = InboundTableAdapter.GetData
            Dim Row As Truck_ScaleDataSet.InboundRow = Tbl.FindByID(InboundId)
            If Not Row Is Nothing Then
                If Row.IsTimes_ViewedNull Then Row.Times_Viewed = 0
                Row.Times_Viewed += 1
                If Row.Times_Viewed > 3 Then
                    Row.Locked = True
                End If
                UnLockSystem(Row.Access_Code)
            End If
            InboundTableAdapter.Update(Tbl)
        Else
            ShowError("Cannot Get Data For Inbound ID " + InboundId.ToString)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If


    End Sub

    Public Sub UpdateWeight()
        Me.txtScaleWeight.Text = MainForm.txtScaleWeight.Text
        Me.lblStatus.Text = MainForm.lblStatus.Text

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        UpdateWeight()
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class
