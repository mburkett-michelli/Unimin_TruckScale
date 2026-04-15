<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setup
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
        Dim Database_PathLabel As System.Windows.Forms.Label
        Dim JournalPrinterLabel As System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.SetupDataSet = New Unimin_Truck_Scale.SetupDataSet
        Me.SetupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SetupTableAdapter = New Unimin_Truck_Scale.SetupDataSetTableAdapters.SetupTableAdapter
        Me.Database_PathTextBox = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button1 = New System.Windows.Forms.Button
        Me.JournalPrinterComboBox = New System.Windows.Forms.ComboBox
        Database_PathLabel = New System.Windows.Forms.Label
        JournalPrinterLabel = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SetupDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SetupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Database_PathLabel
        '
        Database_PathLabel.AutoSize = True
        Database_PathLabel.Location = New System.Drawing.Point(9, 31)
        Database_PathLabel.Name = "Database_PathLabel"
        Database_PathLabel.Size = New System.Drawing.Size(81, 13)
        Database_PathLabel.TabIndex = 2
        Database_PathLabel.Text = "Database Path:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(475, 174)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'SetupDataSet
        '
        Me.SetupDataSet.DataSetName = "SetupDataSet"
        Me.SetupDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SetupBindingSource
        '
        Me.SetupBindingSource.DataMember = "Setup"
        Me.SetupBindingSource.DataSource = Me.SetupDataSet
        '
        'SetupTableAdapter
        '
        Me.SetupTableAdapter.ClearBeforeFill = True
        '
        'Database_PathTextBox
        '
        Me.Database_PathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SetupBindingSource, "Database Path", True))
        Me.Database_PathTextBox.Location = New System.Drawing.Point(12, 47)
        Me.Database_PathTextBox.Name = "Database_PathTextBox"
        Me.Database_PathTextBox.Size = New System.Drawing.Size(490, 20)
        Me.Database_PathTextBox.TabIndex = 3
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(508, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'JournalPrinterLabel
        '
        JournalPrinterLabel.AutoSize = True
        JournalPrinterLabel.Location = New System.Drawing.Point(13, 87)
        JournalPrinterLabel.Name = "JournalPrinterLabel"
        JournalPrinterLabel.Size = New System.Drawing.Size(77, 13)
        JournalPrinterLabel.TabIndex = 4
        JournalPrinterLabel.Text = "Journal Printer:"
        '
        'JournalPrinterComboBox
        '
        Me.JournalPrinterComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SetupBindingSource, "JournalPrinter", True))
        Me.JournalPrinterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.JournalPrinterComboBox.FormattingEnabled = True
        Me.JournalPrinterComboBox.Location = New System.Drawing.Point(16, 103)
        Me.JournalPrinterComboBox.Name = "JournalPrinterComboBox"
        Me.JournalPrinterComboBox.Size = New System.Drawing.Size(329, 21)
        Me.JournalPrinterComboBox.TabIndex = 5
        '
        'Setup
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(633, 215)
        Me.Controls.Add(JournalPrinterLabel)
        Me.Controls.Add(Me.JournalPrinterComboBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Database_PathLabel)
        Me.Controls.Add(Me.Database_PathTextBox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.SetupDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SetupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents SetupDataSet As Unimin_Truck_Scale.SetupDataSet
    Friend WithEvents SetupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SetupTableAdapter As Unimin_Truck_Scale.SetupDataSetTableAdapters.SetupTableAdapter
    Friend WithEvents Database_PathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents JournalPrinterComboBox As System.Windows.Forms.ComboBox

End Class
