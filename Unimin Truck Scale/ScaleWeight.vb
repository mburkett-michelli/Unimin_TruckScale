Imports System.Windows.Forms

Public Class ScaleWeight
    Public WithEvents Indicator As WeightIndicator = MainForm.Indicator
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll

    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Dim WeightVal As Integer = TrackBar1.Value
        WeightVal = WeightVal / 20
        WeightVal = WeightVal * 20
        Me.Indicator.SimulateDataRecieved(WeightVal, WeightIndicator.ScaleStatus.Motion)
    End Sub



    Private Sub Indicator_Weight_Change(ByVal Data As WeightIndicator.ScaleData) Handles Indicator.Weight_Change
        CurrentScaleData = Data
        If EnableWeight = False And CurrentScaleData.Weight > 2000 Then
            EnableWeight = True
        ElseIf EnableWeight = True And CurrentScaleData.Weight < 2000 Then
            Me.Close()
        End If

        Me.txtScaleWeight.TextAlign = HorizontalAlignment.Right
        Me.txtScaleWeight.Text = CurrentScaleData.Weight.ToString + " lbs."
        Me.btnZero.Visible = True
        Me.lblStatus.Text = CurrentScaleData.StatusString
    End Sub



    Private Sub btnZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZero.Click
        Me.Indicator.ZeroScale()
        Me.TrackBar1.Value = 0
    End Sub


End Class
