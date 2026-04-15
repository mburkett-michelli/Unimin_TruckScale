Public Class MainForm
    Public WithEvents Indicator As New WeightIndicator

    Public CurrentScaleLockedStatus As Boolean = False
    Event ScaleLockStatusChanged(ByVal Locked As Boolean)

    Friend PromptPrimaryColor As Color
    Friend PromptSecondaryColor As Color
    Dim CurrentColor As Color
    Public CurrentUserCode As Integer
    Dim Dashes As String = "**********"
    Dim StartupScreenDisplayed As Boolean = False

    Private Sub txtScaleWeight_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.btnZero.Focus()
    End Sub

    Private Sub txtScaleWeight_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        End
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Indicator.DataSource = WeightIndicator.Scaletype.Serial

        Me.TrackBar1.Visible = Me.Indicator.DataSource = WeightIndicator.Scaletype.Simulate
        ShowStartupScreen()
        DefaultLocation = Ask.btn1.Top


        ResetSystem()
    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Dim WeightVal As Integer = TrackBar1.Value
        WeightVal = WeightVal / 20
        WeightVal = WeightVal * 20
        Me.Indicator.SimulateDataRecieved(WeightVal, WeightIndicator.ScaleStatus.Motion)
    End Sub

    Private Sub SetRemote(ByVal Data As String)
        Me.txtRemote.Text = Data
    End Sub

    Friend Sub Indicator_Weight_Change(ByVal Data As WeightIndicator.ScaleData) Handles Indicator.Weight_Change
        CurrentScaleData = Data
        Me.lblStatus.Text = CurrentScaleData.StatusString

        If CurrentScaleData.Weight < 2000 Or EnableWeight Then

            Me.txtScaleWeight.TextAlign = ContentAlignment.MiddleRight
            If CurrentScaleData.Weight < 2000 And StartupScreenDisplayed = False Then
                ShowStartupScreen()
            End If

            Me.txtScaleWeight.Text = CurrentScaleData.Weight.ToString + " lbs."
            Me.btnZero.Visible = True
            SetRemote(CurrentScaleData.Weight.ToString.PadLeft(6))
            CurrentScaleLockedStatus = False
        Else
            StartupScreenDisplayed = False
            Me.txtScaleWeight.Text = CurrentScaleData.Weight.ToString + " lbs."
            'Me.txtScaleWeight.TextAlign = ContentAlignment.MiddleCenter
            'Me.txtScaleWeight.Text = Dashes
            Me.btnZero.Visible = False
            SetRemote("      ")
            If CurrentScaleLockedStatus = False Then
                RaiseEvent ScaleLockStatusChanged(True)
            End If
            CurrentScaleLockedStatus = True

        End If

        If EnableWeight = True And CurrentScaleData.Weight < 2000 Then
            LockSystem()
        End If

    End Sub

    Private Sub btnZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZero.Click
        Me.Indicator.ZeroScale()
        Me.TrackBar1.Value = 0
    End Sub

    Public Sub ShowCompanys()
        LeftButtonType = enButtonType.Unimin
        RightButtonType = enButtonType.GrassRoots
        MiddleButtonType = enButtonType.Unimin ' enButtonType.Cancel
        SetPrompts("", "Press Start To Begin", "", "")
        'SetButton(btnLeft, "Unimin", Color.Gold, True)
        btnLeft.Visible = False
        SetButton(BtnMiddle, "Start", Color.Blue, True)
        SetButton(btnRight, "Grass Roots", Color.LimeGreen, False)
    End Sub

    Public Sub ShowStartupScreen()
        StartupScreenDisplayed = True
        SetPrompts("Truck Must Be On Scale", "To Continue", "", "")
        SetPromptColor(Color.Black, Color.Blue)
        MakeButtonsVisable(False, False, False)

    End Sub


    Private Sub Main_ScaleLockStatusChanged(ByVal Locked As Boolean) Handles Me.ScaleLockStatusChanged
        Debug.Print(Locked)
        If Locked = True Then
            ShowCompanys()
        Else
            ShowStartupScreen()
        End If

    End Sub


    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        Me.Indicator.CheckForError = False

        If LeftButtonType = enButtonType.Unimin Then
            My.Forms.UniminScreen.ShowDialog()
            If My.Forms.UniminScreen.Selection <> enLoadSelection.Cancel Then
                Select Case My.Forms.UniminScreen.Selection
                    Case enLoadSelection.DeliveringALoad
                        DeliverUniminLoad()
                    Case enLoadSelection.PickUpFlatbedLoad
                        PickupFlatbedLoad()
                    Case enLoadSelection.PickingUpBulkLoad
                        PickupBulkLoad()
                    Case enLoadSelection.Other
                        Other()
                    Case enLoadSelection.BucketCalibration
                        BucketCalibration()
                End Select


            End If

        End If
        Me.Indicator.CheckForError = True
    End Sub



    Public Sub CheckUnimin()
        If LeftButtonType = enButtonType.Unimin Then
            My.Forms.UniminScreen.ShowDialog()
            If My.Forms.UniminScreen.Selection <> enLoadSelection.Cancel Then
                Select Case My.Forms.UniminScreen.Selection
                    Case enLoadSelection.DeliveringALoad
                        DeliverUniminLoad()
                    Case enLoadSelection.PickUpFlatbedLoad
                        PickupFlatbedLoad()
                    Case enLoadSelection.PickingUpBulkLoad
                        PickupBulkLoad()
                    Case enLoadSelection.Other
                        Other()
                    Case enLoadSelection.BucketCalibration
                        BucketCalibration()
                End Select


            End If

        End If
    End Sub





















    Private Sub tmrPromptUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPromptUpdate.Tick
        If CurrentColor = Me.PromptSecondaryColor Then
            CurrentColor = Me.PromptPrimaryColor
        Else
            CurrentColor = Me.PromptSecondaryColor
        End If
        Me.lblPrompt1.ForeColor = CurrentColor
        Me.lblPrompt2.ForeColor = CurrentColor
        Me.lblPrompt3.ForeColor = CurrentColor
        Me.lblPrompt4.ForeColor = CurrentColor

    End Sub

    Private Sub txtScaleWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScaleWeight.Click

        'End
    End Sub

    Private Sub BtnMiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMiddle.Click
        Me.Indicator.CheckForError = False

        If MiddleButtonType = enButtonType.Cancel Then
            LockSystem()
        ElseIf MiddleButtonType = enButtonType.ReprintDeliveredUnimin Then
            PrintGTNTicket()
        ElseIf MiddleButtonType = enButtonType.ReprintInboundUnimin Then
            Module1.PrintInboundTicket()
        ElseIf MiddleButtonType = enButtonType.Print Then
            PrintGrossTicket()
        Else
            CheckUnimin()
        End If
        Me.Indicator.CheckForError = True
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click


        If RightButtonType = enButtonType.GrassRoots Then
            Me.Indicator.CheckForError = False


            Dim Response As DialogResult
            Response = AskQuestion("Are You Empty Or Loaded", "Empty", "Loaded", Color.Blue, Color.Yellow, Color.DarkSeaGreen)
            If Response = Windows.Forms.DialogResult.Yes Then
                GetInboundTicket(GrassRoots, "Take Weigh Ticket", "And Follow Grass Roots", "Signs To", "Loading Area")

            ElseIf Response = DialogResult.No Then
                Dim RandomAccessCode As Integer = FindRandomAccessCode()
                If RandomAccessCode <> -1 Then

                    Dim InboundRow As Truck_ScaleDataSet.InboundRow
                    InboundRow = GetInboundRow(RandomAccessCode, True)
                    If InboundRow Is Nothing Then
                        LockSystem()
                        Exit Sub
                    Else
                        If InboundRow.Locked = True Then
                            ShowError("Maximum Number Of Trys To Get Heavy Weight. Go To Unimin Office To Unlock")
                            LockSystem()
                            Exit Sub
                        End If
                    End If

                    Dim Product_TA As New Truck_ScaleDataSetTableAdapters.ProductsTableAdapter
                    Dim ProductTbl As New Truck_ScaleDataSet.ProductsDataTable
                    ProductTbl = Product_TA.GetData
                    If ProductTbl.Count = 0 Then
                        ShowError("No Product In Database")
                        LockSystem()
                        Exit Sub
                    End If
                    List.ButtonArray = New List.ButtonInfo(ProductTbl.Count) {}

                    For I As Integer = 0 To ProductTbl.Count - 1
                        List.ButtonArray(I).ButtonIndex = I
                        List.ButtonArray(I).ButtonName = ProductTbl(I).Product_Name
                        List.ButtonArray(I).ButtonColor = Color.GreenYellow
                    Next

                    List.Label1.Text = "Select Product"
                    List.SetButtons(0)
                    List.BackColor = Color.Thistle
                    If List.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If YesNo("Is Your Truck On Scale And Ready For Heavy Weight") = Windows.Forms.DialogResult.Yes Then
                            'Yes
                            My.Forms.CheckWeight.InboundId = InboundRow.ID

                            If My.Forms.CheckWeight.ShowDialog = DialogResult.OK Then
                                StoreCompletedTransaction(InboundRow.ID, GrassRoots, InboundRow.Time_In, Now, "", "", List.DataString, CurrentWeight, InboundRow.Weight, RandomAccessCode, False, "")
                                SetPrompts("Take Both Copies Of ", "Weigh Ticket and Proceed To ", "Grass Roots Loading Site For", "Bill Of Lading")

                            Else
                                ShowError("Return To Grass Roots And Adjust Load. Then Return To Scale To Continue", True)
                                LockSystem()

                            End If
                        Else
                            'No
                            ShowError(PlaceTruckOnScale, True)
                            LockSystem()
                        End If

                    Else
                        LockSystem()
                    End If
                Else
                    LockSystem()
                End If
            End If
        Else
            LockSystem()
        End If


        Me.Indicator.CheckForError = True
    End Sub

    Private Sub lblPrompt4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtRemote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemote.TextChanged

    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll

    End Sub

    Private Sub btnZero_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnZero.VisibleChanged
        Me.btnZero.Visible = False
    End Sub
End Class
