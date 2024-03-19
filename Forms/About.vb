Public NotInheritable Class About

    Dim dragging As Boolean
    Dim startPoint As Point

    Public Property Title As String
    Public Property VersionNumber As String
    Public Property Copyright As String
    Public Property Description As String
    Public Property AccentColor As Color
    Public Property FontColor As Color
    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Title = "" Then
            Title = "No title provided"
        End If

        If VersionNumber = "" Then
            VersionNumber = "Unknown"
        End If

        If Copyright = "" Then
            Copyright = "Unknown"
        End If

        If Description = "" Then
            Description = "No developer notes provided"
        End If

        Me.Text = Title
        Me.LblTitle.Text = "About: " & Title
        Me.TxtProductName.Text = Title
        Me.TxtVersion.Text = "Ver: " & VersionNumber
        Me.TxtCopyright.Text = "Copyright: " & Copyright
        Me.TextBoxDescription.Text = "What it does..." & vbCrLf & vbCrLf & Description
        Me.Panel1.BackColor = AccentColor
        Me.Panel2.BackColor = AccentColor
        Me.LblTitle.ForeColor = FontColor
        Me.LblXToClose.ForeColor = FontColor
    End Sub

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Close()
    End Sub

    Private Sub LblXToClose_Click(sender As Object, e As EventArgs) Handles LblXToClose.Click
        Me.Close()
    End Sub
    ' Consolidated Mouse Event Handlers
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, LblTitle.MouseDown, Panel2.MouseDown, LogoPictureBox.MouseDown
        If e.Button = MouseButtons.Left Then
            dragging = True
            startPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, LblTitle.MouseMove, Panel2.MouseMove, LogoPictureBox.MouseMove
        If dragging Then
            Dim p As Point = Me.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(p.X - startPoint.X, p.Y - startPoint.Y)
        End If
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, LblTitle.MouseUp, Panel2.MouseUp, LogoPictureBox.MouseUp
        If e.Button = MouseButtons.Left Then
            dragging = False
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class
