Public Class ErrorBox

    Private Sub ErrorBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.BackColor = Color.Yellow Then
            Me.BackColor = Color.Red
        Else
            Me.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub lblPrompt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPrompt.Click

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Close()

    End Sub
End Class