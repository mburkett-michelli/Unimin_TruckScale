Imports System.Windows.Forms

Public Class NumaricKeyBoard
    Public Data As String
    Public DontUseDecimal As Boolean = False

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtInput.Text += " "
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtInput.Text = ""
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Data = Me.txtInput.Text.Trim
        If Me.Data = "" Then Me.Data = Nothing
        If Not Me.Data = Nothing Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Data = Nothing
        Me.Close()

    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button32.Click, Button3.Click, Button2.Click, Button10.Click, Button1.Click
        If sender.text = "." And DontUseDecimal = True Then
            Exit Sub
        End If
        Me.txtInput.Text += sender.text
    End Sub


    Private Sub NumaricKeyBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtInput.Text = ""
    End Sub
End Class
