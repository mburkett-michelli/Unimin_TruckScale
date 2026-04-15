Imports System.Windows.Forms

Public Class PrintingTicket

    

    Private Sub tmrClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrClose.Tick
        MainForm.Indicator.tmrComError.Enabled = True
        MainForm.Enabled = True
        Me.Close()
    End Sub

    Private Sub PrintingTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainForm.Enabled = False
        Me.tmrClose.Enabled = False
        MainForm.Indicator.tmrComError.Enabled = False

    End Sub
End Class
