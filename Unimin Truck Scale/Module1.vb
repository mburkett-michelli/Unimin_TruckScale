Imports System.Drawing.Printing
Module Module1

    Public Enum enLoadSelection
        DeliveringALoad
        PickUpFlatbedLoad
        PickingUpBulkLoad
        Other
        BucketCalibration
        Cancel
    End Enum

    Public Enum enLocation
        UpperLocation
        LowerLocation
    End Enum

    Public ButtonLocation As enLocation
    Public DefaultLocation As Integer

    Friend Const Unimin As String = "Unimin"
    Friend Const GrassRoots As String = "Grass Roots"

    Friend Const WhoAreYouHaulingFor As String = "Press Start To Begin ?"
    Friend Const TruckMustBeOnScaleToStart As String = "Truck Must Be On Scale To Start"
    Public GTNTicket As New GTNTicket
    Public InboundTicket As New InboundTicket
    Public JournalTicket As New Journal
    Public Const PlaceTruckOnScale As String = "Position Truck On Scale And Return To Complete Transaction"

    Public Enum enButtonType
        Unimin
        GrassRoots
        Cancel
        Print
        YesPrintTicketForGrassRoots
        NoPrintTicketForGrassRoots
        ReprintDeliveredUnimin
        ReprintInboundUnimin

    End Enum

    Public LeftButtonType, MiddleButtonType, RightButtonType As enButtonType

    Public Sub ResetGTNTicket()
        With GTNTicket
            .SetParameterValue(.Parameter_Bucket_calibration.ParameterFieldName, False)
            .SetParameterValue(.Parameter_Gross.ParameterFieldName, 0)
            .SetParameterValue(.Parameter_Pit.ParameterFieldName, "")
            .SetParameterValue(.Parameter_Site.ParameterFieldName, "")
            .SetParameterValue(.Parameter_Tare.ParameterFieldName, 0)
            .SetParameterValue(.Parameter_Transaction.ParameterFieldName, 0)
            .SetParameterValue(.Parameter_TimeOut.ParameterFieldName, Now)
            .SetParameterValue(.Parameter_Product.ParameterFieldName, "")
            .SetParameterValue(.Parameter_UniminTicket.ParameterFieldName, True)
            .SetParameterValue(.Parameter_Access_Code_Description.ParameterFieldName, "")
        End With
    End Sub


    Public Sub ResetSystem()
        Try
            Dim Form As Windows.Forms.Form
            ButtonLocation = enLocation.UpperLocation
            For Each Form In My.Application.OpenForms
                If Not Form.Equals(My.Forms.MainForm) Then
                    Form.Close()
                End If
                If CurrentScaleData.Weight < 2000 Then
                    My.Forms.MainForm.ShowStartupScreen()
                Else
                    My.Forms.MainForm.ShowCompanys()

                End If

            Next
            ResetGTNTicket()
        Catch ex As Exception

        End Try


    End Sub


    Friend Sub PrintGTNTicket(Optional ByVal TicketCount As Integer = 1)
        My.Forms.PrintingTicket.Show()
        My.Application.DoEvents()

        GTNTicket.PrintToPrinter(TicketCount, False, 1, 1)
        My.Forms.PrintingTicket.tmrClose.Enabled = True

    End Sub


    Public Sub SetPrompts(ByVal Prompt1 As String, ByVal Prompt2 As String, ByVal Prompt3 As String, ByVal Prompt4 As String)
        With MainForm
            .lblPrompt1.Text = Prompt1
            .lblPrompt2.Text = Prompt2
            .lblPrompt3.Text = Prompt3
            .lblPrompt4.Text = Prompt4
        End With
    End Sub

    Friend Sub SetPromptColor(ByVal Primary As Color, ByVal Secondary As Color)
        With MainForm
            .PromptPrimaryColor = Primary
            .PromptSecondaryColor = Secondary
        End With

    End Sub


    Public Sub GetInboundTicket(ByVal CompanyName As String, _
                                Optional ByVal Prompt1 As String = "Take Weigh Ticket", _
                                Optional ByVal Prompt2 As String = "", _
                                Optional ByVal Prompt3 As String = " Proceed To Office", _
                                Optional ByVal Prompt4 As String = "", _
                                Optional ByVal ErrorString As String = PlaceTruckOnScale)
        If YesNo("Is Your Truck On Scale And Ready For Light Weight") = Windows.Forms.DialogResult.Yes Then
            'Yes
            Dim UserCode As Integer = Random()
            StoreInbound(CompanyName, UserCode, -1, True, True, "")
            SetPrompts(Prompt1, Prompt2, Prompt3, Prompt4)
            UnLockSystem(UserCode)
            MakeButtonsVisable(False, True, False)
            SetButton(MainForm.BtnMiddle, "Reprint", Color.SteelBlue, True)
            MiddleButtonType = enButtonType.ReprintInboundUnimin

        Else

            ShowError(ErrorString, True)
            LockSystem()





        End If



    End Sub
    Private Sub StoreFlatbedLoad(ByVal Product As String)
        Dim RandomAccessCode As Integer = FindRandomAccessCode()
        If RandomAccessCode <> -1 Then
            Dim InboundRow As Truck_ScaleDataSet.InboundRow
            InboundRow = GetInboundRow(RandomAccessCode, True)
            If InboundRow Is Nothing Then
                LockSystem()
                Exit Sub
            Else
                If InboundRow.Locked = True Then
                    ShowError("Maximum Number Of Trys To Get Heavy Weight." + vbCrLf + "Go To Unimin Office To Unlock Scale ")
                    LockSystem()
                    Exit Sub
                End If
            End If
            If YesNo("Is Your Truck On Scale And Ready For Heavy Weight") = Windows.Forms.DialogResult.Yes Then
                'Yes
                My.Forms.CheckWeight.InboundId = InboundRow.ID

                If My.Forms.CheckWeight.ShowDialog = DialogResult.OK Then
                    StoreCompletedTransaction(InboundRow.ID, Unimin, InboundRow.Time_In, Now, "", "", Product, CurrentWeight, InboundRow.Weight, RandomAccessCode, False, "")
                    SetPrompts("Take Weigh Ticket", "Proceed To Office For", "Bill Of Lading", "")
                Else
                    ShowError(PlaceTruckOnScale, True)
                    LockSystem()
                End If


            Else
                LockSystem()
            End If
        Else
            LockSystem()
        End If

    End Sub

    Public Sub PickupFlatbedLoad()
        Dim Response As DialogResult
        Response = AskQuestion("Are You Empty Or Loaded", "Empty", "Loaded", Color.Blue, Color.Yellow, Color.DarkSeaGreen)
        If Response = Windows.Forms.DialogResult.Yes Then
            ''Empty
            GetInboundTicket(Unimin)
        ElseIf Response = DialogResult.No Then
            ''Loaded
            Response = AskQuestion("Select Type Of Bag You Are Hauling", "100 lb Paper Bag", "3000 lb Bulk Bag", Color.Turquoise, Color.YellowGreen, Color.PaleGoldenrod)
            If Response = Windows.Forms.DialogResult.Yes Then
                '100 bag
                StoreFlatbedLoad("100 lb Paper Bag")
            ElseIf Response = DialogResult.No Then
                '3000 bag
                StoreFlatbedLoad("IBC")
            End If
        Else
            LockSystem()
        End If
    End Sub

    Friend Sub StoreCompletedTransaction(ByVal InboundId As Integer, _
                                        ByVal Company_Name As String, _
                                        ByVal Time_In As Date, _
                                        ByVal Time_Out As Date, _
                                        ByVal Pit As String, _
                                        ByVal Pit_Site As String, _
                                        ByVal Product As String, _
                                        ByVal Gross As Integer, _
                                        ByVal Tare As Integer, _
                                        ByVal AccessCode As Integer, _
                                        ByVal StoredAccessCode As Boolean, _
                                        ByVal AccessCodeDescription As String)

        ''System.Drawing.Printing.PrinterSettings.



        Dim CompletedTransactionTableAdapter As New Truck_ScaleDataSetTableAdapters.Completed_TransactionsTableAdapter
        Dim CompletedTbl As New Truck_ScaleDataSet.Completed_TransactionsDataTable
        CompletedTbl = CompletedTransactionTableAdapter.GetData
        Dim row As Truck_ScaleDataSet.Completed_TransactionsRow
        row = CompletedTbl.NewCompleted_TransactionsRow
        Dim G, T As Integer
        If Tare > Gross Then
            G = Tare
            T = Gross
        Else
            T = Tare
            G = Gross
        End If
        With row
            .Transaction_Number = InboundId
            .Company_Name = Company_Name
            .Time_In = Time_In
            .Time_Out = Time_Out
            .Pit = Pit
            .Pit_Site = Pit_Site
            .Product = Product
            .Gross = Gross
            .Tare = Tare
            .Inbound_Access_Code = AccessCode
        End With
        CompletedTbl.AddCompleted_TransactionsRow(row)

        CompletedTransactionTableAdapter.Update(CompletedTbl)


        With GTNTicket
            .SetParameterValue(.Parameter_Bucket_calibration.ParameterFieldName, False)
            .SetParameterValue(.Parameter_Gross.ParameterFieldName, row.Gross)
            .SetParameterValue(.Parameter_Pit.ParameterFieldName, row.Pit)
            .SetParameterValue(.Parameter_Site.ParameterFieldName, row.Pit_Site)
            .SetParameterValue(.Parameter_Tare.ParameterFieldName, row.Tare)
            .SetParameterValue(.Parameter_Transaction.ParameterFieldName, row.Transaction_Number)
            .SetParameterValue(.Parameter_TimeOut.ParameterFieldName, Now)
            .SetParameterValue(.Parameter_Product.ParameterFieldName, row.Product)
            .SetParameterValue(.Parameter_UniminTicket.ParameterFieldName, Company_Name = Unimin)
            .SetParameterValue(.Parameter_Access_Code_Description.ParameterFieldName, AccessCodeDescription)
        End With
        If Company_Name = Unimin Then
            PrintGTNTicket(1)
        Else
            PrintGTNTicket(2)
        End If


        Dim SetupTableAdapter As New SetupDataSetTableAdapters.SetupTableAdapter
        Dim SetupTbl As New SetupDataSet.SetupDataTable
        SetupTbl = SetupTableAdapter.GetData

        Dim pkInstalledPrinters As String
        Dim SetupRow As SetupDataSet.SetupRow = SetupTbl(0)
        If Not SetupRow.IsJournalPrinterNull Then
            For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1
                pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
                If pkInstalledPrinters = SetupRow.JournalPrinter Then
                    With JournalTicket
                        Try

                            .PrintOptions.PrinterName = SetupRow.JournalPrinter
                            .SetParameterValue(.Parameter_Product.ParameterFieldName, row.Product)
                            .SetParameterValue(.Parameter_Access_Code.ParameterFieldName, row.Inbound_Access_Code)
                            .SetParameterValue(.Parameter_Gross.ParameterFieldName, row.Gross)
                            .SetParameterValue(.Parameter_Tare.ParameterFieldName, row.Tare)
                            .SetParameterValue(.Parameter_Time_Out.ParameterFieldName, row.Time_Out)
                            .SetParameterValue(.Parameter_Transaction_Number.ParameterFieldName, row.Transaction_Number)
                            .PrintOptions.PrinterName = pkInstalledPrinters
                            '   .PrintToPrinter(1, False, 1, 1)
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                        End Try

                    End With

                End If


            Next
        End If





        Dim InboundTableAdapter As New Truck_ScaleDataSetTableAdapters.InboundTableAdapter
        Dim InboundRow As Truck_ScaleDataSet.InboundRow
        Dim InboundTable As New Truck_ScaleDataSet.InboundDataTable
        InboundTable = InboundTableAdapter.GetData
        InboundRow = InboundTable.FindByID(InboundId)
        Dim AccessCodetableAdapter As New Truck_ScaleDataSetTableAdapters.Access_CodesTableAdapter
        Dim AccessTbl As New Truck_ScaleDataSet.Access_CodesDataTable
        AccessTbl = AccessCodetableAdapter.GetDataByIdCode(InboundRow.Access_Code)
        StoredAccessCode = AccessTbl.Count > 0


        If StoredAccessCode = True Then
            InboundTable = InboundTableAdapter.GetData
            InboundRow = InboundTable.FindByID(InboundId)
            InboundTableAdapter.Insert(InboundRow.Time_In, InboundRow.Weight, False, 0, InboundRow.Access_Code_Index, InboundRow.Access_Code)
        End If
        InboundTableAdapter.DeleteByInboundId(InboundId)
        UnLockSystem(row.Inbound_Access_Code)

        MakeButtonsVisable(False, True, False)
        SetButton(MainForm.BtnMiddle, "Reprint", Color.SteelBlue, True)
        MiddleButtonType = enButtonType.ReprintDeliveredUnimin

    End Sub


    Public Function GetInboundRow(ByVal AccessCode As Integer, ByVal DisplayErrorMsg As Boolean) As Truck_ScaleDataSet.InboundRow
        Dim InboundTableAdapter As New Truck_ScaleDataSetTableAdapters.InboundTableAdapter
        Dim InboundTbl As New Truck_ScaleDataSet.InboundDataTable
        InboundTbl = InboundTableAdapter.GetDataByAccessCode(AccessCode)
        If InboundTbl.Count = 0 Then
            If DisplayErrorMsg = True Then ShowError("Cannot Find Inbound Information For Access Code " + AccessCode.ToString)
            LockSystem()
            Return Nothing
        End If
        Return InboundTbl(0)
    End Function


    Public Function IdCode() As Truck_ScaleDataSet.Access_CodesRow

        NumaricKeyBoard.Label1.Text = "Key In Access Code Then Press OK"
        If NumaricKeyBoard.ShowDialog = DialogResult.OK Then
            Dim UserInput As String
            UserInput = NumaricKeyBoard.Data
            Dim CodeInteger As Integer
            Try
                CodeInteger = CType(UserInput, Integer)
            Catch ex As Exception
                Return Nothing
            End Try
            Dim AccessCodesDataSet As New Truck_ScaleDataSetTableAdapters.Access_CodesTableAdapter
            Dim Tbl As Truck_ScaleDataSet.Access_CodesDataTable
            Tbl = AccessCodesDataSet.GetDataByIdCode(CodeInteger)
            If Tbl.Count = 0 Then
                ShowError("Invalid Access Code")
                Return Nothing
            Else
                IdCode = Tbl(0)
            End If
        Else
            Return Nothing
        End If

    End Function




    Public Function FindRandomAccessCode() As Integer
        NumaricKeyBoard.Label1.Text = "Key In Access Code Then Press OK"
        If NumaricKeyBoard.ShowDialog = DialogResult.OK Then
            FindRandomAccessCode = CType(NumaricKeyBoard.Data, Integer)
        Else
            FindRandomAccessCode = -1
        End If

    End Function


    Public Sub BucketCalibration()
        Dim AccessCode As Truck_ScaleDataSet.Access_CodesRow = IdCode()

        If Not AccessCode Is Nothing Then
            Dim Response As DialogResult
            Response = AskQuestion("Are You Empty Or Loaded", "Empty", "Loaded", Color.Blue, Color.Yellow, Color.DarkSeaGreen)
            If Response = Windows.Forms.DialogResult.Yes Then
                ''Empty 
                Dim InboundTableAdapter As New Truck_ScaleDataSetTableAdapters.InboundTableAdapter
                Dim tbl As Truck_ScaleDataSet.InboundDataTable = InboundTableAdapter.GetDataByAccessCode(AccessCode.Code)
                Dim Row As Truck_ScaleDataSet.InboundRow
                If tbl.Count = 0 Then
                    Row = tbl.NewInboundRow
                Else
                    Row = tbl(0)
                End If

                Row.Weight = CurrentWeight()
                Row.Times_Viewed = 0
                Row.Access_Code = AccessCode.Code
                Row.Time_In = Now
                If tbl.Count = 0 Then
                    tbl.AddInboundRow(Row)
                End If
                InboundTableAdapter.Update(tbl)
                With InboundTicket

                    .SetParameterValue(.Parameter_Access_Code_Description.ParameterFieldName, AccessCode.Description)
                    .SetParameterValue(.Parameter_Gross.ParameterFieldName, Row.Weight)
                    .SetParameterValue(.Parameter_Transaction.ParameterFieldName, -1)
                    .SetParameterValue(.Parameter_Access_Code.ParameterFieldName, Row.Access_Code)
                    .SetParameterValue(.Parameter_TimeOut.ParameterFieldName, Row.Time_In)
                    .SetParameterValue(.Parameter_ShowTicketNumber.ParameterFieldName, False)
                    .SetParameterValue(.Parameter_ShowTareHeader.ParameterFieldName, False)
                    .SetParameterValue(.Parameter_UniminTicket.ParameterFieldName, True)
                    PrintInboundTicket()
                End With
                SetPrompts("Light Weight Stored ", "Take Weigh Ticket and", "Record On Clipboard", "")
                MakeButtonsVisable(False, True, False)
                SetButton(MainForm.BtnMiddle, "Reprint", Color.SteelBlue, True)
                MiddleButtonType = enButtonType.ReprintInboundUnimin
                UnLockSystem(AccessCode.Code)


            ElseIf Response = DialogResult.No Then
                'Loaded
                Dim Ticket As Integer = AccessCode.Code
                If Ticket <> -1 Then
                    Dim InboundRow As Truck_ScaleDataSet.InboundRow
                    InboundRow = GetInboundRow(Ticket, True)
                    If InboundRow Is Nothing Then
                        LockSystem()
                        Exit Sub
                    End If
                    My.Forms.CheckWeight.InboundId = InboundRow.ID

                    If My.Forms.CheckWeight.ShowDialog = DialogResult.OK Then


                        Dim BucketCalibrationTableAdapter As New Truck_ScaleDataSetTableAdapters.BucketCalibrationRecordsTableAdapter
                        Dim Tbl As New Truck_ScaleDataSet.BucketCalibrationRecordsDataTable
                        Tbl = BucketCalibrationTableAdapter.GetData
                        Dim row As Truck_ScaleDataSet.BucketCalibrationRecordsRow
                        row = Tbl.NewBucketCalibrationRecordsRow
                        Dim G, T As Integer
                        Dim CurWt As Integer = CurrentWeight()
                        If InboundRow.Weight > CurWt Then

                            G = InboundRow.Weight
                            T = CurWt
                        Else
                            T = InboundRow.Weight
                            G = CurWt
                        End If
                        With row
                            .Access_Code_Id = AccessCode.Code
                            .Access_Code_Index = AccessCode.ID
                            .Heavy_Weight = G
                            .Heavy_Weight_Time = Now
                            .Light_Weight = T
                            .Light_Weight_Time = Now

                        End With
                        Tbl.AddBucketCalibrationRecordsRow(row)

                        BucketCalibrationTableAdapter.Update(Tbl)


                        With GTNTicket
                            .SetParameterValue(.Parameter_Bucket_calibration.ParameterFieldName, True)
                            .SetParameterValue(.Parameter_Gross.ParameterFieldName, row.Heavy_Weight)
                            .SetParameterValue(.Parameter_Pit.ParameterFieldName, "")
                            .SetParameterValue(.Parameter_Site.ParameterFieldName, "")
                            .SetParameterValue(.Parameter_Tare.ParameterFieldName, row.Light_Weight)
                            .SetParameterValue(.Parameter_Transaction.ParameterFieldName, row.ID)
                            .SetParameterValue(.Parameter_TimeOut.ParameterFieldName, Now)
                            .SetParameterValue(.Parameter_Product.ParameterFieldName, "")

                            .SetParameterValue(.Parameter_UniminTicket.ParameterFieldName, True)
                            .SetParameterValue(.Parameter_Access_Code_Description.ParameterFieldName, AccessCode.Description)

                        End With
                        PrintGTNTicket()


                        UnLockSystem(row.Access_Code_Id)

                        MakeButtonsVisable(False, True, False)
                        SetButton(MainForm.BtnMiddle, "Reprint", Color.SteelBlue, True)
                        MiddleButtonType = enButtonType.ReprintDeliveredUnimin














                        SetPrompts("Ticket Stored", "Take Weigh Ticket and", "Record On Clipboard", "")

                    Else
                        LockSystem()
                    End If
                End If
            Else
                LockSystem()
            End If
        Else
            LockSystem()

        End If


    End Sub

    Public Sub Other()
        Dim AccessCodeRow As Truck_ScaleDataSet.Access_CodesRow = IdCode()
        If Not AccessCodeRow Is Nothing Then
            If AccessCodeRow.IsDescriptionNull Then AccessCodeRow.Description = ""
            InboundTicket.SetParameterValue(InboundTicket.Parameter_Access_Code_Description.ParameterFieldName, AccessCodeRow.Description)
            InboundTicket.SetParameterValue(InboundTicket.Parameter_Access_Code.ParameterFieldName, -1)
            SetPrompts("Press Print To Print Ticket", "", "", "")
            UnLockSystem(AccessCodeRow.Code)
            MakeButtonsVisable(False, False, False)
            SetButton(MainForm.BtnMiddle, "Print", Color.Blue, True)
            MiddleButtonType = enButtonType.Print

        End If
    End Sub


    Public Sub PickupBulkLoad()
        Dim response As DialogResult = AskQuestion("Are You Empty Or Loaded", "Empty", "Loaded", Color.Blue, Color.Yellow, Color.DarkSeaGreen)
        If response = Windows.Forms.DialogResult.Yes Then
            GetInboundTicket(Unimin)
        ElseIf response = DialogResult.No Then
            ''Bulk Loaded
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
                If YesNo("Is Your Truck On Scale And Ready For Heavy Weight") = Windows.Forms.DialogResult.Yes Then
                    'Yes
                    My.Forms.CheckWeight.InboundId = InboundRow.ID

                    If My.Forms.CheckWeight.ShowDialog = DialogResult.OK Then
                        StoreCompletedTransaction(InboundRow.ID, Unimin, InboundRow.Time_In, Now, "", "", "Bulk Load", CurrentWeight, InboundRow.Weight, RandomAccessCode, False, "")
                        SetPrompts("Take Weigh Ticket", "Proceed To Office For", "Bill Of Lading", "(Or loader operator after 4:30 PM)")
                        MiddleButtonType = enButtonType.ReprintDeliveredUnimin
                        MakeButtonsVisable(False, True, False)
                        SetButton(MainForm.BtnMiddle, "Reprint", Color.SteelBlue, True)
                    Else
                        LockSystem()
                    End If
                Else
                    'No
                    LockSystem()
                End If
            Else
                LockSystem()
            End If
        Else
            LockSystem()

        End If

    End Sub

    Public Function Random() As Integer
        Dim RandomSeed As Integer
        Dim Today As Date = Now
        Dim MillisecondString As String = Today.Millisecond.ToString
        MillisecondString = MillisecondString(0)
        Dim MillisecondMultliplier As Integer = (CType(MillisecondString, Integer) + 1)
        If MillisecondMultliplier > 9 Then MillisecondMultliplier = 1
        RandomSeed = MillisecondMultliplier * 1000
        RandomSeed += Today.Millisecond
        Dim inboundtableadapter As New Truck_ScaleDataSetTableAdapters.InboundTableAdapter
        Dim tbl As New Truck_ScaleDataSet.InboundDataTable
        Do
            tbl = inboundtableadapter.GetDataByAccessCode(RandomSeed)
            If tbl.Count = 0 Then Exit Do
            RandomSeed += 1
        Loop


        Return RandomSeed
    End Function



    Public Sub StoreInbound(ByVal CompanyName As String, ByVal AccessCode As Integer, ByVal AccessCodeIndex As Integer, ByVal PrintTicket As Boolean, ByVal ShowTicketNumber As Boolean, ByVal AccessCodeDescription As String)
        Dim Weight As Integer = CurrentWeight()
        Dim InboundTableAdapter As New Truck_ScaleDataSetTableAdapters.InboundTableAdapter
        Dim Tbl As New Truck_ScaleDataSet.InboundDataTable
        Tbl = InboundTableAdapter.GetDataByAccessCode(AccessCode)
        Dim IsNewRow As Boolean = False
        Dim Row As Truck_ScaleDataSet.InboundRow
        If Tbl.Count = 0 Then
            IsNewRow = True
            Tbl = InboundTableAdapter.GetData
            Row = Tbl.NewInboundRow
        Else
            Row = Tbl(0)
        End If

        With Row
            .Time_In = Now
            .Weight = CurrentWeight()
            .Access_Code = AccessCode
            .Access_Code_Index = AccessCodeIndex
        End With
        If IsNewRow Then Tbl.AddInboundRow(Row)

        InboundTableAdapter.Update(Tbl)
        If PrintTicket = True Then

            My.Forms.PrintingTicket.Show()
            My.Application.DoEvents()
            If ShowTicketNumber = True Then

            End If
            With InboundTicket
                .SetParameterValue(.Parameter_Access_Code_Description.ParameterFieldName, AccessCodeDescription)
                .SetParameterValue(.Parameter_Gross.ParameterFieldName, Row.Weight)
                .SetParameterValue(.Parameter_Transaction.ParameterFieldName, Row.ID)
                .SetParameterValue(.Parameter_Access_Code.ParameterFieldName, Row.Access_Code)
                .SetParameterValue(.Parameter_TimeOut.ParameterFieldName, Row.Time_In)
                .SetParameterValue(.Parameter_ShowTicketNumber.ParameterFieldName, ShowTicketNumber)
                .SetParameterValue(.Parameter_ShowTareHeader.ParameterFieldName, True)
                .SetParameterValue(.Parameter_UniminTicket.ParameterFieldName, CompanyName = Unimin)
                PrintInboundTicket()
            End With

        End If

    End Sub

    Public Sub PrintInboundTicket()
        My.Forms.PrintingTicket.Show()
        My.Application.DoEvents()

        InboundTicket.PrintToPrinter(1, False, 1, 1)
        My.Forms.PrintingTicket.tmrClose.Enabled = True

    End Sub


    Public Sub DeliverUniminLoad()
        Dim Response As DialogResult
        Response = AskQuestion("What Are You Delivering", "Mine Feed", "Other", Color.Blue, Color.Yellow, Color.DarkSeaGreen)
        If Response = Windows.Forms.DialogResult.Yes Then
            Dim AccessCode As Truck_ScaleDataSet.Access_CodesRow = IdCode()
            If Not AccessCode Is Nothing Then

                Response = AskQuestion("Are You Empty Or Loaded", "Empty", "Loaded", Color.Blue, Color.Yellow, Color.DarkSeaGreen)
                If Response = Windows.Forms.DialogResult.Yes Then
                    ''Empty
                    If YesNo("Is Your Truck On Scale And Ready For Light Weight") = Windows.Forms.DialogResult.Yes Then
                        'Yes
                        StoreInbound(Unimin, AccessCode.Code, AccessCode.ID, True, False, AccessCode.Description)
                        SetPrompts("Your Tare Weight", "", "Is Now In The System", "")
                        UnLockSystem(AccessCode.Code)
                        MakeButtonsVisable(False, True, False)
                        SetButton(MainForm.BtnMiddle, "Reprint", Color.SteelBlue, True)
                        MiddleButtonType = enButtonType.ReprintInboundUnimin


                    Else
                        ShowError(PlaceTruckOnScale, True)
                        'No 
                        LockSystem()
                    End If
                ElseIf Response = DialogResult.No Then

                    Dim InboundTableAdapter As New Truck_ScaleDataSetTableAdapters.InboundTableAdapter
                    Dim InboundTbl As New Truck_ScaleDataSet.InboundDataTable
                    InboundTbl = InboundTableAdapter.GetDataByAccessCode(AccessCode.Code)
                    If InboundTbl.Count = 0 Then
                        ShowError("Cannot Find Inbound Information For Access Code " + AccessCode.Code.ToString)
                        LockSystem()
                        Exit Sub
                    End If
                    Dim InboundRow As Truck_ScaleDataSet.InboundRow
                    InboundRow = InboundTbl(0)

                    Dim Pit, Site As String
                    Dim Pit_TA As New Truck_ScaleDataSetTableAdapters.PitsTableAdapter
                    Dim PitTbl As New Truck_ScaleDataSet.PitsDataTable
                    PitTbl = Pit_TA.GetData
                    If PitTbl.Count = 0 Then
                        ShowError("No Pits In Database", True)
                        LockSystem()
                        Exit Sub
                    End If
                    List.ButtonArray = New List.ButtonInfo(PitTbl.Count) {}

                    For I As Integer = 0 To PitTbl.Count - 1
                        List.ButtonArray(I).ButtonIndex = I
                        List.ButtonArray(I).ButtonName = PitTbl(I).Pit_Name
                        List.ButtonArray(I).ButtonColor = Color.GreenYellow
                    Next

                    List.Label1.Text = "Select Pit"
                    List.SetButtons(0)
                    List.BackColor = Color.Thistle
                    If List.ShowDialog = Windows.Forms.DialogResult.OK Then

                        Pit = List.DataString
                        Dim Site_TA As New Truck_ScaleDataSetTableAdapters.Pit_SitesTableAdapter
                        Dim SiteTbl As New Truck_ScaleDataSet.Pit_SitesDataTable
                        SiteTbl = Site_TA.GetDataByName(Pit)
                        If SiteTbl.Count = 0 Then
                            ShowError("No Pit Sites In Database", True)
                            LockSystem()
                            Exit Sub
                        End If
                        List.ButtonArray = New List.ButtonInfo(SiteTbl.Count) {}
                        List.Label1.Text = "Select Site For " + Pit
                        For I As Integer = 0 To SiteTbl.Count - 1

                            List.ButtonArray(I).ButtonIndex = I
                            List.ButtonArray(I).ButtonName = SiteTbl(I).Site_Name
                            List.ButtonArray(I).ButtonColor = Color.GreenYellow
                        Next
                        List.SetButtons(0)
                        List.BackColor = Color.Thistle

                        If List.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Site = List.DataString

                            StoreCompletedTransaction(InboundRow.ID, Unimin, InboundRow.Time_In, Now, Pit, Site, "Mine Feed", CurrentWeight, InboundRow.Weight, AccessCode.Code, True, AccessCode.Description)
                            SetPrompts("Take Weight Ticket", "And Unload At", "Specified Stockpile", "")
                        Else
                            LockSystem()
                        End If
                    Else
                        LockSystem()
                    End If
                Else
                    LockSystem()
                End If

            Else
                LockSystem()
            End If


            'Delivering Other
        ElseIf Response = DialogResult.No Then
            SetPrompts("", "Proceed To Office", "", "")
            MakeButtonsVisable(False, False, False)
            SetButton(MainForm.BtnMiddle, "Cancel", Color.Red, True)
            MiddleButtonType = enButtonType.Cancel

        Else
            LockSystem()
        End If
    End Sub


    Public Sub PrintGrossTicket()


        My.Forms.PrintingTicket.Show()
        My.Application.DoEvents()

        With InboundTicket

            .SetParameterValue(.Parameter_Gross.ParameterFieldName, CurrentWeight)
            .SetParameterValue(.Parameter_Transaction.ParameterFieldName, -1)
            .SetParameterValue(.Parameter_TimeOut.ParameterFieldName, Now)
            .SetParameterValue(.Parameter_ShowTicketNumber.ParameterFieldName, False)
            .SetParameterValue(.Parameter_ShowTareHeader.ParameterFieldName, False)
            .SetParameterValue(.Parameter_UniminTicket.ParameterFieldName, True)
            .PrintToPrinter(1, False, 1, 1)
        End With
        My.Forms.PrintingTicket.tmrClose.Enabled = True

    End Sub


    Public Sub LockSystem()
        MainForm.Enabled = True
        EnableWeight = False
        ResetSystem()

    End Sub


    Public Sub UnLockSystem(ByVal UserCode As Integer)

        Dim Weight_DisplayedTableAdapter As New Truck_ScaleDataSetTableAdapters.Weight_DisplayedTableAdapter
        Weight_DisplayedTableAdapter.Insert(UserCode, Now, CurrentWeight)
        EnableWeight = True

    End Sub



    Public Sub ShowError(ByVal Msg As String, Optional ByVal TimerEnabled As Boolean = False)
        ErrorBox.lblPrompt.Text = Msg
        ErrorBox.Timer2.Enabled = True ' TimerEnabled
        ErrorBox.ShowDialog()

    End Sub


    Public Function AskQuestion(ByVal Question As String, ByVal Button1Text As String, ByVal Button2Text As String) As Windows.Forms.DialogResult
        With My.Forms.Ask
            .btn1.Text = Button1Text
            .btn2.Text = Button2Text
            .lblPrompt.Text = Question
        End With
        Return (My.Forms.Ask.ShowDialog())
    End Function

    Public Function AskQuestion(ByVal Question As String, ByVal Button1Text As String, ByVal Button2Text As String, ByVal ButtonColor1 As Object, ByVal ButtonColor2 As Object) As Windows.Forms.DialogResult
        With My.Forms.Ask
            .btn1.Text = Button1Text
            .btn1.BackColor = ButtonColor1
            .btn2.Text = Button2Text
            .btn2.BackColor = ButtonColor2
            .lblPrompt.Text = Question
        End With
        Return (My.Forms.Ask.ShowDialog())
    End Function

    Public Function AskQuestion(ByVal Question As String, ByVal Button1Text As String, ByVal Button2Text As String, ByVal ButtonColor1 As Object, ByVal ButtonColor2 As Object, ByVal FormBAckColor As Object) As Windows.Forms.DialogResult
        With My.Forms.Ask
            .btn1.Text = Button1Text
            .btn1.BackColor = ButtonColor1
            .btn2.Text = Button2Text
            .btn2.BackColor = ButtonColor2
            .BackColor = FormBAckColor
            .lblPrompt.Text = Question
            .BtnCancel.Visible = True
            .BtnCancel.BackColor = Color.Red
            .BtnCancel.Text = "Cancel"
        End With
        Return (My.Forms.Ask.ShowDialog())
    End Function



    Friend Sub MakeButtonsVisable(ByVal LeftButton As Boolean, ByVal MiddleButton As Boolean, ByVal RightButton As Boolean)
        With MainForm
            .btnLeft.Visible = LeftButton
            .BtnMiddle.Visible = MiddleButton
            .btnRight.Visible = RightButton
        End With
    End Sub

    Friend Sub SetButton(ByVal Button As Windows.Forms.Button, ByVal ButtonText As String, ByVal ButtonColor As Color, Optional ByVal ButtonVisable As Boolean = True)
        Button.Text = ButtonText
        Button.BackColor = ButtonColor
        Button.Visible = ButtonVisable
    End Sub




    Public Function YesNo(ByVal Question As String) As Windows.Forms.DialogResult
        With My.Forms.Ask
            .btn1.Text = "Yes"
            .btn1.BackColor = Color.Lime
            .BtnCancel.Visible = False
            .btn2.Text = "No"
            .btn2.BackColor = Color.Red
            .lblPrompt.Text = Question
        End With
        Return (My.Forms.Ask.ShowDialog())
    End Function

    Public Function CurrentWeight() As Integer

        Return CurrentScaleData.Weight
    End Function


    Public EnableWeight As Boolean = False
    Public CloseForms As Boolean = False
    Public WeightTrigger As Single
    Public CurrentScaleData As WeightIndicator.ScaleData






End Module
