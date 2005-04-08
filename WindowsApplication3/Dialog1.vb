Imports System.Windows.Forms
Imports System.IO

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim myProcess As System.Diagnostics.Process = _
        New System.Diagnostics.Process()
        myProcess.StartInfo.FileName = _
           Directory.GetCurrentDirectory() + "\windowsPk config.exe"
        myProcess.StartInfo.WindowStyle = _
           System.Diagnostics.ProcessWindowStyle.Normal
        Try
            myProcess.Start()
        Catch ex As Exception
            MsgBox("Unable to find the setup program, please put it in the same directory")
        End Try

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
