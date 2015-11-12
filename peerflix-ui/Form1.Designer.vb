<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits MaterialSkin.Controls.MaterialForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SearchTextBox = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.SearchResults = New System.Windows.Forms.ListBox()
        Me.SearchButton = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.VideoPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.MaterialTabSelector1 = New MaterialSkin.Controls.MaterialTabSelector()
        Me.MaterialTabControl1 = New MaterialSkin.Controls.MaterialTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.StatusLabel = New MaterialSkin.Controls.MaterialLabel()
        CType(Me.VideoPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MaterialTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchTextBox.Depth = 0
        Me.SearchTextBox.Hint = ""
        Me.SearchTextBox.Location = New System.Drawing.Point(448, 6)
        Me.SearchTextBox.MouseState = MaterialSkin.MouseState.HOVER
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.SearchTextBox.SelectedText = ""
        Me.SearchTextBox.SelectionLength = 0
        Me.SearchTextBox.SelectionStart = 0
        Me.SearchTextBox.Size = New System.Drawing.Size(267, 23)
        Me.SearchTextBox.TabIndex = 1
        Me.SearchTextBox.Text = "Search term, keywords"
        Me.SearchTextBox.UseSystemPasswordChar = False
        '
        'SearchResults
        '
        Me.SearchResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchResults.FormattingEnabled = True
        Me.SearchResults.Location = New System.Drawing.Point(448, 35)
        Me.SearchResults.Name = "SearchResults"
        Me.SearchResults.Size = New System.Drawing.Size(389, 290)
        Me.SearchResults.TabIndex = 2
        '
        'SearchButton
        '
        Me.SearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchButton.Depth = 0
        Me.SearchButton.Location = New System.Drawing.Point(721, 6)
        Me.SearchButton.MouseState = MaterialSkin.MouseState.HOVER
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Primary = True
        Me.SearchButton.Size = New System.Drawing.Size(116, 23)
        Me.SearchButton.TabIndex = 4
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'VideoPlayer
        '
        Me.VideoPlayer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VideoPlayer.Enabled = True
        Me.VideoPlayer.Location = New System.Drawing.Point(3, 6)
        Me.VideoPlayer.Name = "VideoPlayer"
        Me.VideoPlayer.OcxState = CType(resources.GetObject("VideoPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.VideoPlayer.Size = New System.Drawing.Size(439, 325)
        Me.VideoPlayer.TabIndex = 0
        '
        'MaterialTabSelector1
        '
        Me.MaterialTabSelector1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaterialTabSelector1.BaseTabControl = Me.MaterialTabControl1
        Me.MaterialTabSelector1.Depth = 0
        Me.MaterialTabSelector1.Location = New System.Drawing.Point(0, 64)
        Me.MaterialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabSelector1.Name = "MaterialTabSelector1"
        Me.MaterialTabSelector1.Size = New System.Drawing.Size(851, 23)
        Me.MaterialTabSelector1.TabIndex = 5
        Me.MaterialTabSelector1.Text = "MaterialTabSelector1"
        '
        'MaterialTabControl1
        '
        Me.MaterialTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaterialTabControl1.Controls.Add(Me.TabPage1)
        Me.MaterialTabControl1.Controls.Add(Me.TabPage2)
        Me.MaterialTabControl1.Depth = 0
        Me.MaterialTabControl1.Location = New System.Drawing.Point(0, 89)
        Me.MaterialTabControl1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabControl1.Name = "MaterialTabControl1"
        Me.MaterialTabControl1.SelectedIndex = 0
        Me.MaterialTabControl1.Size = New System.Drawing.Size(851, 366)
        Me.MaterialTabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.VideoPlayer)
        Me.TabPage1.Controls.Add(Me.SearchTextBox)
        Me.TabPage1.Controls.Add(Me.SearchButton)
        Me.TabPage1.Controls.Add(Me.SearchResults)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(843, 340)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Player"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(843, 325)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Config"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'StatusLabel
        '
        Me.StatusLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Depth = 0
        Me.StatusLabel.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.StatusLabel.Location = New System.Drawing.Point(12, 459)
        Me.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(33, 19)
        Me.StatusLabel.TabIndex = 7
        Me.StatusLabel.Text = "Idle"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 487)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.MaterialTabSelector1)
        Me.Controls.Add(Me.MaterialTabControl1)
        Me.Name = "Form1"
        Me.Text = "peerflix-ui"
        CType(Me.VideoPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MaterialTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents VideoPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents SearchTextBox As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents SearchResults As ListBox
    Friend WithEvents SearchButton As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialTabSelector1 As MaterialSkin.Controls.MaterialTabSelector
    Friend WithEvents MaterialTabControl1 As MaterialSkin.Controls.MaterialTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents StatusLabel As MaterialSkin.Controls.MaterialLabel
End Class
