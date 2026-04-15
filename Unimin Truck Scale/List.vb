Public Class List
    Public Data As Integer = -1
    Public DataString As String = ""
    Public LastButtonIndex As Integer

    Structure ButtonInfo
        Dim ButtonIndex As Integer
        Dim ButtonName As String

        Dim ButtonColor As Color
    End Structure



    Public ButtonArray As ButtonInfo()


    Public Sub SetButtons(ByVal Index As Integer)
        Dim Button As Windows.Forms.Button
        For Each Button In Me.Panel1.Controls
            Button.Visible = False
            If ButtonArray.Length - 1 > Index Then
                Button.Visible = True
                Button.BackColor = ButtonArray(Index).ButtonColor
                Button.Text = ButtonArray(Index).ButtonName

                Index += 1

            End If
        Next Button
        Me.LastButtonIndex = Index
    End Sub

  
    Private Sub BtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ButtonsShown As Integer = 0
        Dim ButtonsAvailable As Integer = 0
        Dim Button As Windows.Forms.Button
        For Each Button In Me.Panel1.Controls
            If Button.visible = True Then
                ButtonsShown += 1
            End If
            ButtonsAvailable += 1
        Next
        Me.LastButtonIndex = Me.LastButtonIndex - (ButtonsShown + ButtonsAvailable)
        If Me.LastButtonIndex < 0 Then Me.LastButtonIndex = 0
        SetButtons(LastButtonIndex)
    End Sub




   

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetButtons(LastButtonIndex)
    End Sub



  

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Data = -1
        DataString = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button10.Click, Button1.Click
        Data = -1
        Dim Item As Integer
        For Item = 0 To ButtonArray.Length - 1
            If ButtonArray(Item).ButtonName = sender.text Then
                Data = ButtonArray(Item).ButtonIndex
                DataString = ButtonArray(Item).ButtonName
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Next

    End Sub

    Private Sub List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class