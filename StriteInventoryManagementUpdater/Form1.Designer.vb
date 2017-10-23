<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StriteInventoryManagementUpdater
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StriteInventoryManagementUpdater))
        Me.UpdateNotify = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.RightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MPOpen = New System.Windows.Forms.Button()
        Me.LPOpen = New System.Windows.Forms.Button()
        Me.TBMasterProgram = New System.Windows.Forms.TextBox()
        Me.TBLocalProgram = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.UpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnCheckForUpdate = New System.Windows.Forms.Button()
        Me.RightClickMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'UpdateNotify
        '
        Me.UpdateNotify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.UpdateNotify.BalloonTipText = "Update available for Strite Inventory Management software. Please click here or u" &
    "se the client to update to the newest version."
        Me.UpdateNotify.BalloonTipTitle = "Update"
        Me.UpdateNotify.ContextMenuStrip = Me.RightClickMenu
        Me.UpdateNotify.Icon = CType(resources.GetObject("UpdateNotify.Icon"), System.Drawing.Icon)
        Me.UpdateNotify.Text = "Strite Inventory Management Update"
        Me.UpdateNotify.Visible = True
        '
        'RightClickMenu
        '
        Me.RightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.RightClickMenu.Name = "RightClickMenu"
        Me.RightClickMenu.Size = New System.Drawing.Size(117, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem1.Text = "Settings"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'MPOpen
        '
        Me.MPOpen.Enabled = False
        Me.MPOpen.Location = New System.Drawing.Point(404, 23)
        Me.MPOpen.Name = "MPOpen"
        Me.MPOpen.Size = New System.Drawing.Size(75, 23)
        Me.MPOpen.TabIndex = 1
        Me.MPOpen.Text = "Change..."
        Me.MPOpen.UseVisualStyleBackColor = True
        '
        'LPOpen
        '
        Me.LPOpen.Enabled = False
        Me.LPOpen.Location = New System.Drawing.Point(404, 62)
        Me.LPOpen.Name = "LPOpen"
        Me.LPOpen.Size = New System.Drawing.Size(75, 23)
        Me.LPOpen.TabIndex = 2
        Me.LPOpen.Text = "Change..."
        Me.LPOpen.UseVisualStyleBackColor = True
        '
        'TBMasterProgram
        '
        Me.TBMasterProgram.Enabled = False
        Me.TBMasterProgram.Location = New System.Drawing.Point(12, 25)
        Me.TBMasterProgram.Name = "TBMasterProgram"
        Me.TBMasterProgram.Size = New System.Drawing.Size(386, 20)
        Me.TBMasterProgram.TabIndex = 4
        '
        'TBLocalProgram
        '
        Me.TBLocalProgram.Enabled = False
        Me.TBLocalProgram.Location = New System.Drawing.Point(12, 64)
        Me.TBLocalProgram.Name = "TBLocalProgram"
        Me.TBLocalProgram.Size = New System.Drawing.Size(386, 20)
        Me.TBLocalProgram.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Master Program Location (Server):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Local Program Location (This PC):"
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Location = New System.Drawing.Point(12, 87)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(193, 13)
        Me.lblstatus.TabIndex = 8
        Me.lblstatus.Text = "Program is... (up to date/not up to date)"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(12, 113)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(169, 13)
        Me.lblDate.TabIndex = 9
        Me.lblDate.Text = "Last updated... (date last updated)"
        '
        'OpenFile
        '
        Me.OpenFile.DefaultExt = "exe"
        Me.OpenFile.FileName = "Choose File..."
        Me.OpenFile.InitialDirectory = "C:\"
        Me.OpenFile.Title = "Open..."
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(402, 113)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'UpdateTimer
        '
        Me.UpdateTimer.Interval = 3600000
        '
        'btnCheckForUpdate
        '
        Me.btnCheckForUpdate.Location = New System.Drawing.Point(294, 113)
        Me.btnCheckForUpdate.Name = "btnCheckForUpdate"
        Me.btnCheckForUpdate.Size = New System.Drawing.Size(104, 23)
        Me.btnCheckForUpdate.TabIndex = 11
        Me.btnCheckForUpdate.Text = "Check For Update"
        Me.btnCheckForUpdate.UseVisualStyleBackColor = True
        '
        'StriteInventoryManagementUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 151)
        Me.Controls.Add(Me.btnCheckForUpdate)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblstatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBLocalProgram)
        Me.Controls.Add(Me.TBMasterProgram)
        Me.Controls.Add(Me.LPOpen)
        Me.Controls.Add(Me.MPOpen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StriteInventoryManagementUpdater"
        Me.ShowInTaskbar = False
        Me.Text = "SIM Updater"
        Me.RightClickMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UpdateNotify As NotifyIcon
    Friend WithEvents RightClickMenu As ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents lblDate As Label
    Friend WithEvents lblstatus As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TBLocalProgram As TextBox
    Friend WithEvents TBMasterProgram As TextBox
    Friend WithEvents LPOpen As Button
    Friend WithEvents MPOpen As Button
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents btnUpdate As Button
    Friend WithEvents UpdateTimer As Timer
    Friend WithEvents btnCheckForUpdate As Button
End Class
