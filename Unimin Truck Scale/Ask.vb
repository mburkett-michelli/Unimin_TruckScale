Public Class Ask

    Private Sub Ask_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim btn As Windows.Forms.Button
        For Each btn In Me.Panel1.Controls

            If ButtonLocation = enLocation.LowerLocation Then
                btn.Top = Module1.DefaultLocation + btn.Height
            Else
                btn.Top = Module1.DefaultLocation
            End If

        Next
        If ButtonLocation = enLocation.LowerLocation Then
            ButtonLocation = enLocation.UpperLocation
        Else
            ButtonLocation = enLocation.LowerLocation
        End If
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click

    End Sub
End Class