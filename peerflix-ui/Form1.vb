Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports AxWMPLib
Imports ThePirateBay
Imports WMPLib

Public Class Form1

    Private ls As IEnumerable(Of Torrent)
    Private proc As Process
    'Private iw As StreamWriter

    ''' <summary>
    ''' Initializers
    ''' </summary>
    Sub New()
        Me.Icon = My.Resources.peerflix_ui_beta

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' ThePirateBay Search function
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        StatusLabel.Text = "Searching for " & SearchTextBox.Text
        ls = Nothing
        Dim query As New Query(SearchTextBox.Text)
        Dim torrents As IEnumerable(Of Torrent)
        Try
            torrents = Tpb.Search(query)
        Catch ex As Exception
            MessageBox.Show("Could not search: " & ex.Message)
        End Try
#Disable Warning
        If torrents IsNot Nothing Then
            If torrents.Count > 0 Then
                ls = torrents
                SearchResults.Items.Clear()
                For Each torrent As Torrent In torrents
                    SearchResults.Items.Add(torrent.Name)
                Next
            Else
                StatusLabel.Text = "No search results were found"
            End If
        End If
#Enable Warning
    End Sub

    ''' <summary>
    ''' The DoubleClick event of SearchResults ListBox, plays a stream
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchResults_DoubleClick(sender As Object, e As EventArgs) Handles SearchResults.DoubleClick
        If SearchResults.SelectedIndex <> -1 Then
            For Each torrent As Torrent In ls
                If torrent.Name = SearchResults.SelectedItem.ToString Then
                    StartPeerflix(torrent.Name, torrent.Magnet)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Starts the peerflix service, located based on PATH variable
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="magnet"></param>
    Private Sub StartPeerflix(name As String, magnet As String)
        StopPeerflix()
        StatusLabel.Text = "Starting playback of " & name
        Dim psi As New ProcessStartInfo()
        psi.FileName = "peerflix" 'LocatePeerflix()
        psi.Arguments = magnet
        'psi.RedirectStandardInput = True
        psi.UseShellExecute = True
        psi.CreateNoWindow = True
        psi.WindowStyle = ProcessWindowStyle.Hidden
        proc = Process.Start(psi)
        'iw = proc.StandardInput
        VideoPlayer.URL = "http://" & Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(Function(ip) ip.AddressFamily = AddressFamily.InterNetwork).ToString & ":8888/"
        StatusLabel.Text = "Playing " & name
    End Sub

    ''' <summary>
    ''' Stops the peerflix process along with nodejs (process tree)
    ''' </summary>
    Private Sub StopPeerflix()
        If proc IsNot Nothing Then
            If proc.Handle <> IntPtr.Zero Then
                If Not proc.HasExited Then
                    'iw.WriteLine("\x3")
                    'iw.WriteLine("y")
                    'iw.Close()
                    StatusLabel.Text = "Stopping playback.."
                    Application.DoEvents()
                    VideoPlayer.Ctlcontrols.stop()
                    VideoPlayer.URL = ""
                    VideoPlayer.currentPlaylist.clear()
                    TerminateProcessTree(proc.Handle, proc.Id, 0)
                    StatusLabel.Text = "Idle"
                    'proc.Kill()
                End If
            End If
        End If
    End Sub

#Region "Kill process tree"
    '''<summary>
    ''' Terminate a process tree
    '''</summary>
    '''<param name="hProcess">The handle of the process</param>
    '''<param name="processID">The ID of the process</param>
    '''<param name="exitCode">The exit code of the process</param>
    Public Sub TerminateProcessTree(hProcess As IntPtr, processID As UInteger, exitCode As Integer)
        ' Retrieve all processes on the system
        Dim processes As Process() = Process.GetProcesses()
        For Each p As Process In processes
            ' Get some basic information about the process
            Dim pbi As New PROCESS_BASIC_INFORMATION()
            Try
                Dim bytesWritten As UInteger
                NtQueryInformationProcess(p.Handle, 0, pbi, CUInt(Marshal.SizeOf(pbi)), bytesWritten)
                ' == 0 is OK
                ' Is it a child process of the process we're trying to terminate?
                If pbi.InheritedFromUniqueProcessId = processID Then
                    ' The terminate the child process and its child processes
                    TerminateProcessTree(p.Handle, pbi.UniqueProcessId, exitCode)
                End If
            Catch generatedExceptionName As Exception
                ' Ignore, most likely 'Access Denied'
                ' ex 
            End Try
        Next

        ' Finally, termine the process itself:
        TerminateProcess(CUInt(hProcess), exitCode)
    End Sub

    ' [StructLayout(LayoutKind.Sequential)]
    Private Structure PROCESS_BASIC_INFORMATION
        Public ExitStatus As Integer
        Public PebBaseAddress As Integer
        Public AffinityMask As Integer
        Public BasePriority As Integer
        Public UniqueProcessId As UInteger
        Public InheritedFromUniqueProcessId As UInteger
    End Structure

    <DllImport("kernel32.dll")>
    Private Shared Function TerminateProcess(hProcess As UInteger, exitCode As Integer) As Boolean
    End Function

    <DllImport("ntdll.dll")>
    Private Shared Function NtQueryInformationProcess(hProcess As IntPtr, processInformationClass As Integer, ByRef processBasicInformation As PROCESS_BASIC_INFORMATION, processInformationLength As UInteger, ByRef returnLength As UInteger) As Integer
    End Function
#End Region

    ''' <summary>
    ''' Locate peerflix.cmd (not currently needed)
    ''' </summary>
    ''' <returns>String path to peerflix.cmd</returns>
    Private Function LocatePeerflix() As String
        Dim paths() As String = Split(Environment.GetEnvironmentVariable("PATH"), ";")
        Dim messageOutput As String = ""
        Dim fileInPath As String = "peerflix.cmd"
        For Each pathItem In paths
            If File.Exists(pathItem & "\" & fileInPath) Then
                Return pathItem & "\" & fileInPath
            End If
        Next
        Return String.Empty
    End Function

    Private Sub VideoPlayer_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles VideoPlayer.PlayStateChange
        Select Case e.newState
            Case 1 'Stop 
                StopPeerflix()
            Case 2 'Paused
            Case 3 'Play
        End Select
    End Sub

    ''' <summary>
    ''' Closes the form, shuts down the peerflix/nodejs service
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        StopPeerflix()
    End Sub

    ''' <summary>
    ''' KeyDown event for SearchText, used to search on Keys.Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            SearchButton.PerformClick()
        End If
    End Sub

End Class