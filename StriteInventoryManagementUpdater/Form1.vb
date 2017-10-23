'-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
'Project: Strite Inventory Management Software Updater
'Description: Software built with the purpose of checking and applying udates to the in-house software "Strite Inventory Management"
'Created By: Nick Hallick
'            Process Engineer
'            nhallick@strite.com
'            519-658-9361 ext.344
'Project Start Date: 24/08/2017
'Project End Date: 28/08/2017
'Revision: 1.0.0 (Published)

'***********************************************************************************************************************************************************************
'The Dreaded TODO Section


'***********************************************************************************************************************************************************************
'-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Imports System.ComponentModel
Imports System.IO
Imports System.Diagnostics
Public Class StriteInventoryManagementUpdater
    Dim CloseForm As Boolean
    Dim Fdatemaster As String
    Dim Fnamemaster As String
    Dim Fdatelocal As String
    Dim Fnamelocal As String
    Dim Answer As String
    Dim n As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateTimer.Start()
        btnUpdate.Enabled = False
        'initialize the master and local program locations. This information is stored in the programs settings and is saved before the program exits in case of change.
        TBMasterProgram.Text = My.Settings.MasterProgram
        TBLocalProgram.Text = My.Settings.LocalProgram
        lblDate.Text = "Last updated: " & My.Settings.LastUpdated
        'check for update when program starts. Users usually shut down programs at end of day so this ensures when they start up again the next day it will notify them of updates from the previous day.
        BtnCheckForUpdate_Click(Nothing, Nothing)
        'handler in charge of monitoring the computer for shut down events. triggers if the user shuts down the computer
        AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf Handler_sessionending
    End Sub

    Public Sub Handler_sessionending(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionEndingEventArgs)
        'when the handler is triggered (Upon computer shutdown) handle the program shutting down accordingly by saving settings and closing properly
        If e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
            My.Settings.Save()
            CloseForm = True
            UpdateNotify.Dispose()
            Close()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'when the exit button on the right click menu is clicked then save settings and close program properly
        My.Settings.Save()
        CloseForm = True
        UpdateNotify.Dispose()
        Close()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        'when the settings button on the right click menu is clicked then show the form if it isnt already shown
        Show()
        WindowState = FormWindowState.Normal
        BringToFront()
    End Sub

    Private Sub UpdateNotify_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles UpdateNotify.MouseDoubleClick
        'when the notification area icon is double clicked then check the window state and maximize if minimized and vice versa
        If WindowState = 0 Then
            SendToBack()
            WindowState = FormWindowState.Minimized
            Hide()
        Else
            Show()
            WindowState = FormWindowState.Normal
            BringToFront()
        End If

    End Sub

    Private Sub StriteInventoryManagementUpdater_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'if the close button on the form is clicked then intercept the closing event and prevent it. Instead just minimize the window and send it to the back. Also save the settings just in case
        If CloseForm = False Then
            WindowState = FormWindowState.Minimized
            e.Cancel = True
        End If
        My.Settings.Save()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs)
        'if the ok button is pressed on the form then minimize the window
        'this is put there in case the user is aprehensive of clicking the close button to minimize.
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MPOpen_Click(sender As Object, e As EventArgs) Handles MPOpen.Click
        'When the master program open button is clicked open a file dialog window and allow the user to choose the master program .exe
        OpenFile.Title = "Choose master program file location..."
        OpenFile.ShowDialog()

        'set the textbox text to the file path
        TBMasterProgram.Text = OpenFile.FileName
        'set the master program variable in settings to the file path as well
        My.Settings.MasterProgram = OpenFile.FileName
        My.Settings.Save()
    End Sub

    Private Sub LPOpen_Click(sender As Object, e As EventArgs) Handles LPOpen.Click
        'identical to the master program open code but for the local program
        OpenFile.Title = "Choose local program file location..."
        OpenFile.ShowDialog()
        TBLocalProgram.Text = OpenFile.FileName
        My.Settings.LocalProgram = OpenFile.FileName
        My.Settings.Save()
    End Sub

    Function GetDirPath(ByVal file As String) As String
        'simple function to retrieve the file directory path of whichever file is passed through it
        Dim fi As New FileInfo(file)
        Return fi.Directory.ToString
    End Function

    Private Sub UpdateTimer_Tick(sender As Object, e As EventArgs) Handles UpdateTimer.Tick
        'timer object used to check the local program against the master program. checks to see if they match and if they do not prompt for an update.
        Fnamemaster = My.Settings.MasterProgram
        'checks the last modified date for the master program
        'modify will only happen if either the program code is altered or the program is renamed
        Fdatemaster = File.GetLastWriteTime(Fnamemaster)

        Fnamelocal = My.Settings.LocalProgram
        'checks the last modified date for the local program
        Fdatelocal = File.GetLastWriteTime(Fnamelocal)

        'chekcs to see if the local and master program have the same date. if they do not then it starts the process to notify the user of an available update.
        If Fdatemaster <> Fdatelocal Then
            lblstatus.Text = "Local program is out of date. Please update as soon as convenient."
            'shows a balloon notification for 500ms before fading
            UpdateNotify.ShowBalloonTip(500)

            'ask the user if they would like to update at this time and save their respose (vbYes/vbNo)
            Answer = MsgBox("A new version of Strite Inventory Management is available, would you like to update?", vbYesNo + vbInformation, "Update?")
            If Answer = vbYes Then
                'calls the clicking event for the update button
                BtnUpdate_Click(Nothing, Nothing)
                'gets rid of the notify balloon early
                UpdateNotify.Visible = False
                UpdateNotify.Visible = True
            Else

            End If
        Else
            lblstatus.Text = "Local program is up to date, no update needed at this time!"
            btnUpdate.Enabled = False
        End If


        My.Settings.Save()
    End Sub

    Private Sub BtnCheckForUpdate_Click(sender As Object, e As EventArgs) Handles btnCheckForUpdate.Click
        Dim rand As New Random

        'pointless fun code to change colour of the update button every 11 clicks. This is here purely for the fact that I wanted to see if I could do it. Turns out I can.
        'If it gets annoying I will comment it out but I can only see it being a great idea
        n = n + 1
        If n = 10 Then
            n = 0
            btnCheckForUpdate.BackColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256))
        End If

        'Check the last modified date of the master program
        Fnamemaster = My.Settings.MasterProgram
        Fdatemaster = File.GetLastWriteTime(Fnamemaster)

        'check the last modified date of the local program
        Fnamelocal = My.Settings.LocalProgram
        Fdatelocal = File.GetLastWriteTime(Fnamelocal)

        'if the last modified dates of the master and local programs do not match then enable the update button. If the programs are the same then make sure the update button is not enabled
        If Fdatemaster <> Fdatelocal Then
            lblstatus.Text = "Local program is out of date. Please update as soon as convenient."
            btnUpdate.Enabled = True
        Else
            lblstatus.Text = "Local program is up to date, no update needed at this time!"
            btnUpdate.Enabled = False
        End If


        My.Settings.Save()
    End Sub

    Private Sub UpdateNotify_BalloonTipClicked(sender As Object, e As EventArgs) Handles UpdateNotify.BalloonTipClicked
        'If the user clicks on the notification balloon prompt then call the update button clicked event
        BtnUpdate_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'if the update button is clicked then check to see if the program "Strite Inventory Management" is running as it cannot be to update it
        Dim p() As Process

        'run a check of the currently active processes on the computer to check for "Strite Inventory Management"
        p = Process.GetProcessesByName("Strite Inventory Management")
        'if it is running then prompt the user to close it and try updating again
        If p.Count > 0 Then
            MsgBox("Strite Inventory Management is still running. Please close the program and try updating again.", vbCritical, "Error")
            Exit Sub
        Else
            'if it is not running then copy the master program from the specified location and paste it to the local program location, overwriting the local program
            File.Copy(My.Settings.MasterProgram, My.Settings.LocalProgram, True)

            My.Settings.LastUpdated = Date.Now
            lblDate.Text = "Last updated: " & My.Settings.LastUpdated
            lblstatus.Text = "Local program is up to date, no update needed at this time!"
        End If
        btnUpdate.Enabled = False
        My.Settings.Save()
    End Sub

    Private Sub Label1_DoubleClick(sender As Object, e As EventArgs) Handles Label1.DoubleClick
        'used as a rudimentary security measure. master program button and textbox are disabled unless the label is double clicked. can be disabled again by double clicking again.
        If TBMasterProgram.Enabled = False Then
            TBMasterProgram.Enabled = True
        Else
            TBMasterProgram.Enabled = False
        End If

        If MPOpen.Enabled = False Then
            MPOpen.Enabled = True
        Else
            MPOpen.Enabled = False
        End If

    End Sub

    Private Sub Label2_DoubleClick(sender As Object, e As EventArgs) Handles Label2.DoubleClick
        'used as a rudimentary security measure. local program button and textbox are disabled unless the label is double clicked. can be disabled again by double clicking again.
        If TBLocalProgram.Enabled = False Then
            TBLocalProgram.Enabled = True
        Else
            TBLocalProgram.Enabled = False
        End If

        If LPOpen.Enabled = False Then
            LPOpen.Enabled = True
        Else
            LPOpen.Enabled = False
        End If
    End Sub

    Private Sub StriteInventoryManagementUpdater_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'if the program is closed then save its settings
        My.Settings.Save()
    End Sub
End Class
