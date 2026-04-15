Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text



Public Class WeightIndicator
    Dim WithEvents Timer1 As New Windows.Forms.Timer
    Public WithEvents tmrComError As New Windows.Forms.Timer
    Dim WithEvents UdpTimer As New Windows.Forms.Timer
    Dim WithEvents ScalePort As New System.IO.Ports.SerialPort
    Dim WithEvents TmrMotionCancel As New Windows.Forms.Timer




    Private Const ScaleMotion As String = "Motion"
    Private Const ScaleComError As String = "Comm Error"
    Private Const ScaleOk As String = ""
    Private Const ScaleOutOfRange As String = "Out Of Range"

    Private Instring As String
    Event DataRecieved(ByVal RecievedString As String)
    Event Weight_Change(ByVal Data As ScaleData)

    Dim ListenPort As Integer

    Dim listener As UdpClient
    Dim ListenerEP As IPEndPoint

    Dim Transmitter As UdpClient
    Dim TransmitterEP As IPEndPoint

    Private ScaleInformation As ScaleData

    Public CheckForError As Boolean = True

    Public Enum Scaletype
        Simulate
        Serial
        Tcp
        Udp
    End Enum


    Public Function SpanishScaleStatusString(ByVal Status As ScaleStatus) As String
        Select Case Status
            Case ScaleStatus.CommError
                Return "Escala error de comunicación"
            Case ScaleStatus.Motion
                Return "Moción en la escala"
            Case ScaleStatus.OutOfRange
                Return "Escala fuera de alcance"
            Case Else
                Return ""

        End Select
    End Function

    Public Enum ScaleStatus
        CommError
        Motion
        Ok
        OutOfRange
    End Enum


    Public Structure ScaleData
        Dim IndicatorType As Scaletype
        Dim Weight As Long
        Dim Status As ScaleStatus
        Dim StatusString As String
    End Structure


    Public Sub New()
        Try
            Me.ScalePort.NewLine = Chr(13)
            Timer1.Enabled = True
            Me.UdpTimer.Enabled = False
            Timer1.Interval = 500
            tmrComError.Interval = 5000
            Me.UdpTimer.Interval = 500
            Timer1.Start()
            tmrComError.Start()
            Me.ScalePort.BaudRate = 9600
            Me.ScaleInformation.IndicatorType = Scaletype.Simulate
            ScaleInformation.Weight = 0
            ScaleInformation.Status = ScaleStatus.Ok
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Listen()
        Dim done As Boolean = False
        Try
            Dim ByteCount As Integer = listener.Available
            Debug.WriteLine(Now.ToLongTimeString + " Bytecount" + ByteCount.ToString)
            If listener.Available > 0 Then
                Dim bytes As Byte() = listener.Receive(ListenerEP)
                While listener.Available > 0
                    bytes = listener.Receive(ListenerEP)
                End While
                Dim IncomingString As String = (Encoding.ASCII.GetString(bytes, 0, bytes.Length))

                Instring = Instring + IncomingString
                RaiseEvent DataRecieved(Now.ToLongTimeString + " " + Instring)
            End If
        Catch e As Exception
            RaiseEvent DataRecieved(Now.ToLongTimeString + " " + "error.." + e.Message)

        Finally

        End Try
    End Sub


    Public Property DataSource(Optional ByVal ListenPort As Integer = 10001, Optional ByVal TransmitPort As Integer = 10002) As Scaletype
        Get
            DataSource = ScaleInformation.IndicatorType
        End Get
        Set(ByVal value As Scaletype)

            ScaleInformation.IndicatorType = value
            If Me.ScaleInformation.IndicatorType = Scaletype.Serial Then
                Try
                    Me.ScalePort.Open()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                If Me.ScalePort.IsOpen Then
                    Me.ScalePort.Close()
                End If
            End If

            If Me.ScaleInformation.IndicatorType = Scaletype.Udp Then

                listener.Close()
                ListenerEP = New IPEndPoint(IPAddress.Any, ListenPort)
                listener = New UdpClient(ListenerEP)
                TransmitterEP = New IPEndPoint(IPAddress.Any, TransmitPort)
                Transmitter = New UdpClient(TransmitterEP)
                Me.UdpTimer.Enabled = True
            Else
                Me.UdpTimer.Enabled = False
            End If

        End Set
    End Property


    Public Property CommPort()
        Get
            CommPort = Me.ScalePort.PortName
        End Get
        Set(ByVal value)

            If Me.ScaleInformation.IndicatorType = Scaletype.Serial Then
                '                Try
                If Me.ScalePort.IsOpen Then
                    Me.ScalePort.Close()
                End If
                Me.ScalePort.PortName = value
                Me.ScalePort.Open()
                'Catch ex As Exception
                'MsgBox(ex.Message)
                'End Try
            End If
        End Set
    End Property


    Private Function StatusString(ByVal Status As ScaleStatus) As String
        Select Case (Status)
            Case ScaleStatus.Motion
                StatusString = ScaleMotion
            Case ScaleStatus.Ok
                StatusString = ScaleOk
            Case ScaleStatus.OutOfRange
                StatusString = ScaleOutOfRange
            Case ScaleStatus.CommError
                StatusString = ScaleComError
            Case Else
                StatusString = ScaleOk
        End Select


    End Function


    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ScaleInformation.IndicatorType <> Scaletype.Simulate Then
            Dim Weight As Double
            Dim Status As ScaleStatus
            Dim Location As Integer
            Dim WeightString As String
            Location = InStr(Instring, Chr(2))
            If Instring Is Nothing Then Exit Sub
            If Instring = "" Or Location = 0 Or Instring.Length < 16 Then Exit Sub
            Dim I As Integer = Instring.Length
            WeightString = Trim(Mid(Instring, Location + 3, 7))
            If InStr(WeightString, "__") > 0 Or InStr(WeightString, "--") > 0 Then
                Status = ScaleStatus.OutOfRange
                Weight = 0
            Else
                Try
                    Weight = CType(WeightString, Double)
                    If InStr(Instring, "-") > 0 Then Weight = Weight * -1
                    If InStr(Instring, "(") Then
                        Status = ScaleStatus.Motion
                    Else
                        Status = ScaleStatus.Ok
                    End If
                Catch ex As Exception
                    Status = ScaleStatus.CommError
                    Weight = 0
                End Try
                Me.ScaleInformation.Weight = Weight
            End If
            Me.ScaleInformation.Status = Status
            Me.ScaleInformation.StatusString = StatusString(Status)
        End If
        RaiseEvent Weight_Change(Me.ScaleInformation)
        'If Me.ScalePort.IsOpen Then Me.ScalePort.WriteLine(Instring)
        Me.tmrComError.Stop()
        Me.tmrComError.Start()
        Instring = ""

    End Sub


    Private Sub TmrCommError(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrComError.Tick
        If Me.CheckForError = True Then
            Me.ScaleInformation.Status = ScaleStatus.CommError
            Me.ScaleInformation.Weight = 0
            Me.ScaleInformation.StatusString = StatusString(ScaleStatus.CommError)
            RaiseEvent Weight_Change(Me.ScaleInformation)
        End If


    End Sub


    Public Sub SimulateDataRecieved(ByVal Weight As Long, ByVal status As ScaleStatus)
        Me.ScaleInformation.Weight = Weight
        Me.ScaleInformation.Status = status
        Me.ScaleInformation.StatusString = StatusString(status)
        Me.TmrMotionCancel.Interval = 1500
        Me.TmrMotionCancel.Start()

        RaiseEvent Weight_Change(Me.ScaleInformation)
    End Sub


    Public Sub SimulateStatusChange(ByVal status As ScaleStatus)

        Me.ScaleInformation.Status = status
        Me.ScaleInformation.StatusString = StatusString(status)
        RaiseEvent Weight_Change(Me.ScaleInformation)
    End Sub


    Private Sub ScalePort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ScalePort.DataReceived
        Try
            Me.Instring = Me.ScalePort.ReadLine
            Dim CleanString As String = Me.ScalePort.ReadExisting()

        Catch ex As Exception
            ShowError("Scale Error" + ex.Message)
        End Try


    End Sub


    Public Sub ZeroScale()
        If Me.ScaleInformation.IndicatorType = Scaletype.Simulate Then
            SimulateDataRecieved(0, ScaleStatus.Ok)
        ElseIf Me.ScaleInformation.IndicatorType = Scaletype.Serial Then
            Me.ScalePort.WriteLine("KZERO")
        ElseIf ScaleInformation.IndicatorType = Scaletype.Udp Then
            SendToUDP("KZERO")
        End If


    End Sub


    Private Sub SendToUDP(ByVal Info As String)
        If InStr(Info, Chr(13) + Chr(10)) = 0 Then Info = Info + Chr(13) + Chr(10)



        Try

            Me.Transmitter.Connect(Me.TransmitterEP)


            ' Sends a message to the host to which you have connected.
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(Info)

            Me.Transmitter.Send(sendBytes, sendBytes.Length)
            Me.Transmitter.Close()
        Catch e As Exception
        End Try
    End Sub


    Public Function Type_Of_Scale() As Scaletype
        Type_Of_Scale = Me.ScaleInformation.IndicatorType
    End Function


    Private Sub UdpTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UdpTimer.Tick
        Listen()
    End Sub

    Private Sub TmrMotionCancel_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrMotionCancel.Tick
        SimulateStatusChange(ScaleStatus.Ok)
        Me.TmrMotionCancel.Stop()
    End Sub
End Class
