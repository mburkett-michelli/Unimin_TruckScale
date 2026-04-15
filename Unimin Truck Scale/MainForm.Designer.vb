<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PnlStraightWeigh = New System.Windows.Forms.Panel()
        Me.txtScaleWeight = New System.Windows.Forms.Label()
        Me.txtRemote = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnZero = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.lblPrompt1 = New System.Windows.Forms.Label()
        Me.btnRight = New System.Windows.Forms.Button()
        Me.btnLeft = New System.Windows.Forms.Button()
        Me.lblPrompt2 = New System.Windows.Forms.Label()
        Me.lblPrompt3 = New System.Windows.Forms.Label()
        Me.BtnMiddle = New System.Windows.Forms.Button()
        Me.tmrPromptUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.lblPrompt4 = New System.Windows.Forms.Label()
        Me.PnlStraightWeigh.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlStraightWeigh
        '
        Me.PnlStraightWeigh.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PnlStraightWeigh.Controls.Add(Me.txtScaleWeight)
        Me.PnlStraightWeigh.Controls.Add(Me.txtRemote)
        Me.PnlStraightWeigh.Controls.Add(Me.Label7)
        Me.PnlStraightWeigh.Controls.Add(Me.lblStatus)
        Me.PnlStraightWeigh.Controls.Add(Me.btnZero)
        Me.PnlStraightWeigh.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlStraightWeigh.Location = New System.Drawing.Point(0, 0)
        Me.PnlStraightWeigh.Name = "PnlStraightWeigh"
        Me.PnlStraightWeigh.Size = New System.Drawing.Size(800, 207)
        Me.PnlStraightWeigh.TabIndex = 5
        '
        'txtScaleWeight
        '
        Me.txtScaleWeight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtScaleWeight.BackColor = System.Drawing.Color.White
        Me.txtScaleWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleWeight.Location = New System.Drawing.Point(114, 45)
        Me.txtScaleWeight.Name = "txtScaleWeight"
        Me.txtScaleWeight.Size = New System.Drawing.Size(573, 116)
        Me.txtScaleWeight.TabIndex = 12
        Me.txtScaleWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemote
        '
        Me.txtRemote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRemote.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRemote.Font = New System.Drawing.Font("OCR A Extended", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemote.ForeColor = System.Drawing.Color.Red
        Me.txtRemote.Location = New System.Drawing.Point(657, 3)
        Me.txtRemote.Name = "txtRemote"
        Me.txtRemote.Size = New System.Drawing.Size(131, 41)
        Me.txtRemote.TabIndex = 10
        Me.txtRemote.Text = "120000"
        Me.txtRemote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRemote.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(239, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(323, 42)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Scale Weight"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(152, 164)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(496, 39)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZero
        '
        Me.btnZero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZero.Location = New System.Drawing.Point(12, 45)
        Me.btnZero.Name = "btnZero"
        Me.btnZero.Size = New System.Drawing.Size(96, 116)
        Me.btnZero.TabIndex = 0
        Me.btnZero.Text = "Zero Scale"
        Me.btnZero.UseVisualStyleBackColor = False
        Me.btnZero.Visible = False
        '
        'TrackBar1
        '
        Me.TrackBar1.BackColor = System.Drawing.Color.Silver
        Me.TrackBar1.Location = New System.Drawing.Point(0, 0)
        Me.TrackBar1.Maximum = 120000
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(218, 45)
        Me.TrackBar1.SmallChange = 20
        Me.TrackBar1.TabIndex = 6
        Me.TrackBar1.TickFrequency = 1000
        Me.TrackBar1.Visible = False
        '
        'lblPrompt1
        '
        Me.lblPrompt1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrompt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt1.Location = New System.Drawing.Point(0, 210)
        Me.lblPrompt1.Name = "lblPrompt1"
        Me.lblPrompt1.Size = New System.Drawing.Size(800, 60)
        Me.lblPrompt1.TabIndex = 13
        Me.lblPrompt1.Text = "Label1"
        Me.lblPrompt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRight
        '
        Me.btnRight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnRight.BackColor = System.Drawing.Color.GreenYellow
        Me.btnRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRight.Location = New System.Drawing.Point(519, 460)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(238, 111)
        Me.btnRight.TabIndex = 12
        Me.btnRight.Text = "Grass Roots"
        Me.btnRight.UseVisualStyleBackColor = False
        Me.btnRight.Visible = False
        '
        'btnLeft
        '
        Me.btnLeft.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnLeft.BackColor = System.Drawing.Color.Green
        Me.btnLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeft.ForeColor = System.Drawing.Color.White
        Me.btnLeft.Location = New System.Drawing.Point(43, 460)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(238, 111)
        Me.btnLeft.TabIndex = 11
        Me.btnLeft.Text = "Start"
        Me.btnLeft.UseVisualStyleBackColor = False
        Me.btnLeft.Visible = False
        '
        'lblPrompt2
        '
        Me.lblPrompt2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrompt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt2.Location = New System.Drawing.Point(0, 270)
        Me.lblPrompt2.Name = "lblPrompt2"
        Me.lblPrompt2.Size = New System.Drawing.Size(800, 60)
        Me.lblPrompt2.TabIndex = 14
        Me.lblPrompt2.Text = "Label2"
        Me.lblPrompt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPrompt3
        '
        Me.lblPrompt3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrompt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt3.Location = New System.Drawing.Point(0, 330)
        Me.lblPrompt3.Name = "lblPrompt3"
        Me.lblPrompt3.Size = New System.Drawing.Size(800, 60)
        Me.lblPrompt3.TabIndex = 15
        Me.lblPrompt3.Text = "Label3"
        Me.lblPrompt3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnMiddle
        '
        Me.BtnMiddle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnMiddle.BackColor = System.Drawing.Color.Green
        Me.BtnMiddle.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMiddle.ForeColor = System.Drawing.Color.White
        Me.BtnMiddle.Location = New System.Drawing.Point(281, 460)
        Me.BtnMiddle.Name = "BtnMiddle"
        Me.BtnMiddle.Size = New System.Drawing.Size(238, 111)
        Me.BtnMiddle.TabIndex = 17
        Me.BtnMiddle.Text = "Grass Roots"
        Me.BtnMiddle.UseVisualStyleBackColor = False
        Me.BtnMiddle.Visible = False
        '
        'tmrPromptUpdate
        '
        Me.tmrPromptUpdate.Enabled = True
        Me.tmrPromptUpdate.Interval = 500
        '
        'lblPrompt4
        '
        Me.lblPrompt4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrompt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt4.Location = New System.Drawing.Point(0, 390)
        Me.lblPrompt4.Name = "lblPrompt4"
        Me.lblPrompt4.Size = New System.Drawing.Size(800, 60)
        Me.lblPrompt4.TabIndex = 18
        Me.lblPrompt4.Text = "Label4"
        Me.lblPrompt4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.lblPrompt4)
        Me.Controls.Add(Me.BtnMiddle)
        Me.Controls.Add(Me.lblPrompt3)
        Me.Controls.Add(Me.lblPrompt2)
        Me.Controls.Add(Me.lblPrompt1)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.btnLeft)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.PnlStraightWeigh)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlStraightWeigh.ResumeLayout(False)
        Me.PnlStraightWeigh.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlStraightWeigh As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnZero As System.Windows.Forms.Button
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents txtRemote As System.Windows.Forms.TextBox
    Friend WithEvents lblPrompt1 As System.Windows.Forms.Label
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents lblPrompt2 As System.Windows.Forms.Label
    Friend WithEvents lblPrompt3 As System.Windows.Forms.Label
    Friend WithEvents BtnMiddle As System.Windows.Forms.Button
    Friend WithEvents tmrPromptUpdate As System.Windows.Forms.Timer
    Friend WithEvents txtScaleWeight As System.Windows.Forms.Label
    Friend WithEvents lblPrompt4 As System.Windows.Forms.Label

End Class
