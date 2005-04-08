'' show running progs list
'Dim f As Integer
'Dim fff As String = ""
'For f = 0 To running_progs.Length
'    If running_progs(f) = "" Then
'        Continue For
'    End If
'    fff = fff + running_progs(f) + vbNewLine
'Next
'MsgBox(fff)

'' show allowed list
'Dim g As Integer
'Dim ggg As String = ""
'For g = 0 To allowed.Length
'    ggg = ggg + allowed(g) + vbNewLine
'Next
'MsgBox(ggg)




'MsgBox(proc)

' taskkill using proc array
'im = ""
' get processes and add them to the running_progs array
'Dim sProcesses() As System.Diagnostics.Process
'Dim sProcess As System.Diagnostics.Process
'On Error Resume Next
'sProcesses = System.Diagnostics.Process.GetProcesses()
'For Each sProcess In sProcesses
'    If (sProcess.Id > 4) Then
'        running_progs(procint) = sProcess.ProcessName().ToString + ".exe"
'        procint = procint + 1
'    End If
'Next


'System.Threading.Thread.Sleep(50)
'For i = 0 To 200
'    If proc(i) = "" Then
'        Continue For
'    End If
'    im = "/f /im " + proc(i)
'    bar += 1
'    Dim ProcessStartInfo As New System.Diagnostics.ProcessStartInfo()
'    ProcessStartInfo.FileName = "taskkill.exe"
'    ProcessStartInfo.Arguments = im
'    ProcessStartInfo.WorkingDirectory = ""
'    ProcessStartInfo.WindowStyle = ProcessStartInfo.WindowStyle.Hidden
'    ProcessStartInfo.UseShellExecute = True
'    ProcessStartInfo.CreateNoWindow = True
'    System.Diagnostics.Process.Start(ProcessStartInfo)
'    list = ("Stopped process : " + proc(i) & vbNewLine + list)
'    System.Threading.Thread.Sleep(15)

'Next i

'System.Threading.Thread.Sleep(350)
'Dim ProcessStartInfo1 As New System.Diagnostics.ProcessStartInfo()
'ProcessStartInfo1.FileName = "explorer.exe"

'ProcessStartInfo1.WorkingDirectory = ""
'ProcessStartInfo1.WindowStyle = ProcessStartInfo1.WindowStyle.Hidden
'ProcessStartInfo1.UseShellExecute = True
'ProcessStartInfo1.CreateNoWindow = True
'System.Diagnostics.Process.Start(ProcessStartInfo1)
'list = ("Starting Process : Explorer.exe" & vbNewLine + list)