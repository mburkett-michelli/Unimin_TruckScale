<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckWeight
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
        Me.components = New System.ComponentModel.Container
        Me.PnlStraightWeigh = New System.Windows.Forms.Panel
        Me.txtScaleWeight = New System.Windows.Forms.Label
        Me.txtRemote = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.btn1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PnlStraightWeigh.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlStraightWeigh
        '
        Me.PnlStraightWeigh.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PnlStraightWeigh.Controls.Add(Me.txtScaleWeight)
        Me.PnlStraightWeigh.Controls.Add(Me.txtRemote)
        Me.PnlStraightWeigh.Controls.Add(Me.Label7)
        Me.PnlStraightWeigh.Controls.Add(Me.lblStatus)
        Me.PnlStraightWeigh.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlStraightWeigh.Location = New System.Drawing.Point(0, 0)
        Me.PnlStraightWeigh.Name = "PnlStraightWeigh"
        Me.PnlStraightWeigh.Size = New System.Drawing.Size(792, 207)
        Me.PnlStraightWeigh.TabIndex = 6
        '
        'txtScaleWeight
        '
        Me.txtScaleWeight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtScaleWeight.BackColor = System.Drawing.Color.White
        Me.txtScaleWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleWeight.Location = New System.Drawing.Point(147, 45)
        Me.txtScaleWeight.Name = "txtScaleWeight"
        Me.txtScaleWeight.Size = New System.Drawing.Size(499, 116)
        Me.txtScaleWeight.TabIndex = 12
        Me.txtScaleWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemote
        '
        Me.txtRemote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRemote.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRemote.Font = New System.Drawing.Font("OCR A Extended", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemote.ForeColor = System.Drawing.Color.Red
        Me.txtRemote.Location = New System.Drawing.Point(653, 82)
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
        Me.Label7.Location = New System.Drawing.Point(235, 3)
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
        Me.lblStatus.Location = New System.Drawing.Point(148, 164)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(496, 39)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BtnCancel.BackColor = System.Drawing.Color.Red
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(464, 433)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(232, 121)
        Me.BtnCancel.TabIndex = 105
        Me.BtnCancel.Text = "No"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn1.BackColor = System.Drawing.Color.Lime
        Me.btn1.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(97, 433)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(232, 121)
        Me.btn1.TabIndex = 104
        Me.btn1.Text = "Ok"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(792, 223)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Are You OK With The Weight And Ready For Final Weigh Ticket"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckWeight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.PnlStraightWeigh)
        Me.Controls.Add(Me.btn1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CheckWeight"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CheckWeight"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlStraightWeigh.ResumeLayout(False)
        Me.PnlStraightWeigh.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlStraightWeigh As System.Windows.Forms.Panel
    Friend WithEvents txtScaleWeight As System.Windows.Forms.Label
    Friend WithEvents txtRemote As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
