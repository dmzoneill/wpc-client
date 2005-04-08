Imports System.IO
Imports Microsoft.Win32

Public Class Form1
    Dim list As String
    Dim bar As Integer = 0
    Dim itemstokill As Integer
    Dim allowed As New ArrayList() ' allowed apps pre defined
    Dim proc(50) As String ' processes to kill populated by array cross reference
    Dim procint As Integer = 0
    Dim ppp As Integer = 0





    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' list of allowed processes

        If (FindKey("HKEY_LOCAL_MACHINE", "Software\WPK") = True) Then
            Timer3.Enabled = False

            Dim sRegNames As String()
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WPK\allowed", True)
            sRegNames = regKey.GetValueNames
            For Each sRegName As String In sRegNames
                Dim fff As String = regKey.GetValue(sRegName)
                allowed.Add(fff)
            Next
            regKey.Close()

            Dim y As Integer = 0
            Dim p As Process
            For Each p In Process.GetProcesses
                If Not allowed.Contains(p.ProcessName.ToString) Then
                    proc(y) = p.ProcessName.ToString
                    y = y + 1
                End If
            Next

            y = y + 5

            itemstokill = y - 1

            ProgressBar1.Maximum = itemstokill + 1

        Else
            Dim fff As New Dialog1
            fff.ShowDialog()

            Me.Close()
        End If

        

    End Sub


    Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" (ByVal lpBuffer As String, ByRef nSize As Integer) As Integer

    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
        Return GetUserName
    End Function

    Public Function FindKey(ByVal type As String, ByVal key As String)
        Select Case type
            Case "HKEY_LOCAL_MACHINE"
                Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(key, True)
                If Not (regKey Is Nothing) Then
                    Return True
                End If
            Case "HKEY_CURRENT_USER"
                Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key, True)
                If Not (regKey Is Nothing) Then
                    Return True
                End If
            Case "HKEY_CLASSES_ROOT"
                Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(key, True)
                If Not (regKey Is Nothing) Then
                    Return True
                End If
            Case "HKEY_USERS"
                Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.Users.OpenSubKey(key, True)
                If Not (regKey Is Nothing) Then
                    Return True
                End If
            Case "HKEY_CURRENT_CONFIG"
                Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(key, True)
                If Not (regKey Is Nothing) Then
                    Return True
                End If
        End Select
        Return False
    End Function

    Public Sub killer()
        Dim c As String
        Dim g As String = "0"
        Dim regy As RegistryKey
        regy = Registry.LocalMachine.OpenSubKey("SOFTWARE\WPK\settings", True)

        Dim regKey2 As RegistryKey
        regKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        Dim keys2() As String = regKey2.GetValueNames
        Dim ir As Integer
        For ir = 0 To keys2.Length - 1
            If keys2(ir).ToString = "Windows Process Controller" Then
                g = "1"
            End If
        Next
        regKey2.Close()

        Dim im As String = ""
        Dim y As Integer = 0
        Dim p As Process
        For Each p In Process.GetProcesses
            If Not allowed.Contains(p.ProcessName.ToString) Then
                y = y + 1
                Try
                    list = ("Stopped process : " + p.ProcessName.ToString + ".exe" + vbNewLine + list)
                    p.Kill()
                Catch ex As Exception
                    list = ("Unable to stop process : " + p.ProcessName.ToString + ".exe" + vbNewLine + list)
                End Try


                bar += 1
                ppp = ppp + 1
                System.Threading.Thread.Sleep(100)
            End If
        Next
        list = vbNewLine + "Closing unwanted applications :" + vbNewLine + list

        ' remove hklm run 
        c = regy.GetValue("HKLM")
        If c = "1" Then
            Try
                Dim regKey1 As RegistryKey
                regKey1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                Dim keys() As String = regKey1.GetValueNames
                Dim i As Integer
                For i = 0 To keys.Length - 1
                    regKey1.DeleteValue(keys(i).ToString)
                Next
                regKey1.Close()
                bar += 1
                ppp = ppp + 1
                System.Threading.Thread.Sleep(100)
                list = ("Cleared HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" + vbNewLine + list)
            Catch ex As Exception
                list = ("Unable to clear HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" + vbNewLine + list)
            End Try
        Else
            list = ("User Cleanup disabled : HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" + vbNewLine + list)
            bar += 1
            ppp = ppp + 1
        End If


        c = regy.GetValue("HKCU")
        If c = "1" Then
            ' remove hkcu run
            Try
                Dim regKey5 As RegistryKey
                regKey5 = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

                Dim keys25() As String = regKey5.GetValueNames
                Dim irg As Integer
                For irg = 0 To keys25.Length - 1
                    regKey5.DeleteValue(keys2(irg).ToString)
                Next
                regKey5.Close()
                bar += 1
                ppp = ppp + 1
                System.Threading.Thread.Sleep(100)
                list = ("Cleared HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" + vbNewLine + list)
            Catch ex As Exception
                list = ("Unable to clear HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" + vbNewLine + list)

            End Try
        Else
            list = ("User Cleanup disabled : HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" + vbNewLine + list)

            bar += 1
            ppp = ppp + 1
        End If


        ' clear startup folders


        c = regy.GetValue("ALLUSERS")
        If c = "1" Then
            Try
                ' make a reference to a directory
                Dim di As New IO.DirectoryInfo("C:\Documents and Settings\All Users\Start Menu\Programs\Startup")
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                Dim dra As IO.FileInfo
                Dim minty As String
                'list the names of all files in the specified directory
                For Each dra In diar1
                    minty = dra.Name.ToString
                    If Not minty = "desktop.ini" Then
                        dra.Delete()
                    End If
                Next
                bar += 1
                ppp = ppp + 1
                System.Threading.Thread.Sleep(100)
                list = ("Cleared C:\Documents and Settings\All Users\Start Menu\Programs\Startup" + vbNewLine + list)
            Catch ex As Exception
                list = ("Unable to clear C:\Documents and Settings\All Users\Start Menu\Programs\Startup" + vbNewLine + list)
                bar += 1
                ppp = ppp + 1
                System.Threading.Thread.Sleep(100)
            End Try
        Else
            list = ("User Cleanup disabled : C:\Documents and Settings\All Users\Start Menu\Programs\Startup" + vbNewLine + list)

            bar += 1
            ppp = ppp + 1
        End If


        c = regy.GetValue("CURRENT")
        If c = "1" Then
            Try
                ' make a reference to a directory
                Dim uname As String = GetUserName()
                Dim di As New IO.DirectoryInfo("C:\Documents and Settings\" & uname & "\Start Menu\Programs\Startup")
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                Dim dra As IO.FileInfo
                Dim mint As String
                'list the names of all files in the specified directory
                For Each dra In diar1
                    mint = dra.Name.ToString
                    If Not mint = "desktop.ini" Then
                        dra.Delete()
                    End If
                Next
                bar += 1
                ppp = ppp + 1
                System.Threading.Thread.Sleep(100)
                list = ("Cleared C:\Documents and Settings\" & uname & "\Start Menu\Programs\Startup" + vbNewLine + list)

            Catch ex As Exception
                Dim uname As String = GetUserName()
                list = ("Cleared C:\Documents and Settings\" & uname & "\Start Menu\Programs\Startup" + vbNewLine + list)
                bar += 1
                ppp = ppp + 1
                System.Threading.Thread.Sleep(100)
            End Try
            list = vbNewLine + "Clearing windows startup items :" + vbNewLine + list
        Else
            list = ("User Cleanup disabled : Clearing windows startup items" + vbNewLine + list)

            bar += 1
            ppp = ppp + 1
        End If


        ' add The Process killer to windows starup


        If g = "1" Then
            Try
                Dim regKey3 As RegistryKey
                regKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey3.SetValue("Windows Process Controller", "C:\Program Files\Windows Process Controller\wpc.exe")
                list = ("Added Windows Process Controller to the windows startup" + vbNewLine + list)
                bar += 1
                ppp = ppp + 1
            Catch ex As Exception
                list = ("Unable to add Windows Process Controller to the windows startup" + vbNewLine + list)
                bar += 1
                ppp = ppp + 1
            End Try
            list = vbNewLine + "Additional additions :" + vbNewLine + list
        Else
            list = ("User Cleanup disabled : Additional additions" + vbNewLine + list)

            bar += 1
            ppp = ppp + 1
        End If



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (FindKey("HKEY_LOCAL_MACHINE", "Software\WPK") = True) Then
            Timer3.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (FindKey("HKEY_LOCAL_MACHINE", "Software\WPK") = True) Then
            Timer1.Enabled = False
            Timer2.Enabled = True
            Dim NewThread As New Threading.Thread(AddressOf killer)
            NewThread.Start()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If (FindKey("HKEY_LOCAL_MACHINE", "Software\WPK") = True) Then
            TextBox1.Text = list
            ProgressBar1.Value = bar
            If ppp > itemstokill Then
                MsgBox(ppp & "" & itemstokill)
                Timer2.Enabled = False
                Timer3.Enabled = True
            End If
        End If

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If (FindKey("HKEY_LOCAL_MACHINE", "Software\WPK") = True) Then
            Dim c As String
            Dim regKey1 As RegistryKey
            regKey1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\WPK\settings", True)
            c = regKey1.GetValue("close")
            regKey1.Close()
            If c = "yes" Then
                'decreases opacity in turms of timer interval 
                Me.Opacity -= 0.015
                'when opacity is zero the form is invisible and we dispose it
                If Me.Opacity = 0 Then Me.Dispose()

                If Me.Opacity < 0.015 Then
                    Me.Opacity = 100
                    Timer3.Enabled = False
                    Timer2.Enabled = False
                    Timer1.Enabled = False
                    Application.Exit()
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim myProcess As System.Diagnostics.Process = New System.Diagnostics.Process()
        myProcess.StartInfo.FileName = Directory.GetCurrentDirectory() + "\WPC-config.exe"
        myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        Try
            myProcess.Start()
        Catch ex As Exception
            MsgBox("Unable to find the setup program, please put it in the same directory")
        End Try

        Me.Close()
       End Sub
End Class
