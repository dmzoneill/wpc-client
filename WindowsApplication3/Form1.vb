
Public Class Form1
    Dim list As String
    Dim bar As Integer = 0
    Dim itemstokill As Integer = 52
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Form1.Visible = False

        ProgressBar1.Maximum = itemstokill + 1




    End Sub


    Public Sub killer()
        Dim i As Integer
        Dim im As String
        Dim com As String




        im = ""
    
        Dim proc(itemstokill) As String
        proc(0) = "iexplore.exe"
        proc(1) = "ypager.exe"
        proc(2) = "skype.exe"
        proc(3) = "msnmsgr.exe"
        proc(4) = "gg.exe"
        proc(5) = "aim.exe"
        proc(6) = "mirc.exe"
        proc(7) = "icqlite.exe"
        proc(8) = "winword.exe"
        proc(9) = "outlook.exe"
        proc(10) = "msaaccess.exe"
        proc(11) = "infopath.exe"
        proc(12) = "excel.exe"
        proc(13) = "powerpnt.exe"
        proc(14) = "mspub.exe"
        proc(15) = "aom.exe"
        proc(16) = "bf1942.exe"
        proc(17) = "dfbhd.exe"
        proc(18) = "codsp.exe"
        proc(19) = "codmp.exe"
        proc(20) = "generals.exe"
        proc(21) = "game.dat"
        proc(22) = "doom3.exe"
        proc(23) = "empirse_dmw.exe"
        proc(24) = "eve.exe"
        proc(25) = "gta3.exe"
        proc(26) = "maxpayne2.exe"
        proc(27) = "gta-vc.exe"
        proc(28) = "vlc.exe"
        proc(29) = "moh_breakthrough.exe"
        proc(30) = "moh_spearhead.exe"
        proc(31) = "mohaa.exe"
        proc(32) = "motogp.exe"
        proc(33) = "motogp2.exe"
        proc(34) = "quake3.exe"
        proc(35) = "ra2.exe"
        proc(36) = "yuri.exe"
        proc(37) = "wolfmp.exe"
        proc(38) = "nations.exe"
        proc(39) = "pirates!.exe"
        proc(40) = "simcity 4.exe"
        proc(41) = "ut2004.exe"
        proc(42) = "hlds.exe"
        proc(43) = "hl.exe"
        proc(44) = "wmplayer.exe"
        proc(45) = "winamp.exe"
        proc(46) = "realplay.exe"
        proc(47) = "itunes.exe"
        proc(48) = "DAP.exe"
        proc(49) = "firefox.exe"
        proc(50) = "maxthon.exe"
        proc(51) = "limewire.exe"
        proc(52) = "explorer.exe"



        im = ""

        
        System.Threading.Thread.Sleep(50)
        For i = 0 To 52
            im = "/f /im " + proc(i)
            bar += 1
            Dim ProcessStartInfo As New System.Diagnostics.ProcessStartInfo()
            ProcessStartInfo.FileName = "taskkill.exe"
            ProcessStartInfo.Arguments = im
            ProcessStartInfo.WorkingDirectory = ""
            ProcessStartInfo.WindowStyle = ProcessStartInfo.WindowStyle.Hidden
            ProcessStartInfo.UseShellExecute = True
            ProcessStartInfo.CreateNoWindow = True
            System.Diagnostics.Process.Start(ProcessStartInfo)
            list = ("Stopped process : " + proc(i) & vbNewLine + list)
            System.Threading.Thread.Sleep(250)



        Next i
        Dim ProcessStartInfo1 As New System.Diagnostics.ProcessStartInfo()
        ProcessStartInfo1.FileName = "explorer.exe"

        ProcessStartInfo1.WorkingDirectory = ""
        ProcessStartInfo1.WindowStyle = ProcessStartInfo1.WindowStyle.Hidden
        ProcessStartInfo1.UseShellExecute = True
        ProcessStartInfo1.CreateNoWindow = True
        System.Diagnostics.Process.Start(ProcessStartInfo1)
        list = ("Starting Process : Explorer.exe" & vbNewLine + list)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

       
        Timer3.Enabled = True

    End Sub


    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        MsgBox("Written for Click here Internet Cafe by David O Neill" + vbNewLine + vbNewLine + "http://www.clickherecork.com" + vbNewLine + vbNewLine + "info@clickherecork.com" + vbNewLine + "© ClickHere™ Internet Cafe")


    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        MsgBox("There are numerous reasons for this application :" + vbNewLine + "1. People leaving their chat programs open & logged in. The next user can invade your privacy." + vbNewLine + "2. Leaving sensitive documents opened which should have been closed!" + vbNewLine + "3. Many others!")



    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Timer2.Enabled = True
        Dim NewThread As New Threading.Thread(AddressOf killer)
        NewThread.Start()


    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        TextBox1.Text = list

        ProgressBar1.Value = bar
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        'decreases opacity in turms of timer interval 
        Me.Opacity -= 0.01
        'when opacity is zero the form is invisible and we dispose it
        If Me.Opacity = 0 Then Me.Dispose()

        If Me.Opacity < 0.01 Then
            MsgBox("exit")
            'Me.Opacity = 100
            Application.Exit()
            End
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
