Imports System.Drawing

''' <summary>
''' Represents an About form for displaying application information.
''' </summary>
Public NotInheritable Class About

    ''' <summary>
    ''' Flag indicating whether the form is being dragged.
    ''' </summary>
    Private dragging As Boolean

    ''' <summary>
    ''' The starting point for dragging the form.
    ''' </summary>
    Private startPoint As Point

    ''' <summary>
    ''' Gets or sets the title of the application.
    ''' </summary>
    Public Property Title As String

    ''' <summary>
    ''' Gets or sets the version number of the application.
    ''' </summary>
    Public Property VersionNumber As String

    ''' <summary>
    ''' Gets or sets the copyright information of the application.
    ''' </summary>
    Public Property Copyright As String

    ''' <summary>
    ''' Gets or sets the description of the application.
    ''' </summary>
    Public Property Description As String

    ''' <summary>
    ''' Gets or sets the accent color of the form.
    ''' </summary>
    Public Property AccentColor As Color

    ''' <summary>
    ''' Gets or sets the font color of the form.
    ''' </summary>
    Public Property FontColor As Color

    ''' <summary>
    ''' Handles the Load event of the form.
    ''' Initializes the form with provided information or defaults.
    ''' </summary>
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

    ''' <summary>
    ''' Handles the Click event of the OK button.
    ''' Closes the form.
    ''' </summary>
    Private Sub OKButton_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the close label.
    ''' Closes the form.
    ''' </summary>
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
