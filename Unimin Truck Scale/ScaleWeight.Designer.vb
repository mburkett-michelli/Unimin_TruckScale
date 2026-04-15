<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScaleWeight
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
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.PnlStraightWeigh = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.btnZero = New System.Windows.Forms.Button
        Me.txtScaleWeight = New System.Windows.Forms.TextBox
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlStraightWeigh.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(200, 213)
        Me.TrackBar1.Maximum = 120000
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(630, 45)
        Me.TrackBar1.SmallChange = 20
        Me.TrackBar1.TabIndex = 8
        Me.TrackBar1.TickFrequency = 1000
        '
        'PnlStraightWeigh
        '
        Me.PnlStraightWeigh.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PnlStraightWeigh.Controls.Add(Me.Label7)
        Me.PnlStraightWeigh.Controls.Add(Me.lblStatus)
        Me.PnlStraightWeigh.Controls.Add(Me.btnZero)
        Me.PnlStraightWeigh.Controls.Add(Me.txtScaleWeight)
        Me.PnlStraightWeigh.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlStraightWeigh.Location = New System.Drawing.Point(0, 0)
        Me.PnlStraightWeigh.Name = "PnlStraightWeigh"
        Me.PnlStraightWeigh.Size = New System.Drawing.Size(1030, 207)
        Me.PnlStraightWeigh.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(351, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(323, 42)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Scale Weight"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(288, 164)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(496, 39)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZero
        '
        Me.btnZero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZero.Location = New System.Drawing.Point(86, 45)
        Me.btnZero.Name = "btnZero"
        Me.btnZero.Size = New System.Drawing.Size(132, 116)
        Me.btnZero.TabIndex = 0
        Me.btnZero.Text = "Zero Scale"
        Me.btnZero.UseVisualStyleBackColor = False
        '
        'txtScaleWeight
        '
        Me.txtScaleWeight.BackColor = System.Drawing.Color.White
        Me.txtScaleWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleWeight.ForeColor = System.Drawing.Color.Black
        Me.txtScaleWeight.Location = New System.Drawing.Point(246, 45)
        Me.txtScaleWeight.Name = "txtScaleWeight"
        Me.txtScaleWeight.ReadOnly = True
        Me.txtScaleWeight.Size = New System.Drawing.Size(533, 116)
        Me.txtScaleWeight.TabIndex = 4
        Me.txtScaleWeight.Text = "0 lbs."
        Me.txtScaleWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ScaleWeight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 748)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.PnlStraightWeigh)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ScaleWeight"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ScaleWeight"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlStraightWeigh.ResumeLayout(False)
        Me.PnlStraightWeigh.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents PnlStraightWeigh As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnZero As System.Windows.Forms.Button
    Friend WithEvents txtScaleWeight As System.Windows.Forms.TextBox

End Class
