Public Class Form1

    ' Speed of ball
    Dim VSpeed As Single = 2
    Dim HSpeed As Single = -2

    ' Brick rows and cols and spacing
    Dim Rows As Integer = 8
    Dim Cols As Integer = 14
    Dim TopRow As Single = 0.07
    Dim RowHeight As Single = 0.02

    ' Score tracker
    Dim Score As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Check top of screen
        If (Ball.Top < 0) Then
            VSpeed = -VSpeed
        End If

        ' Check left side of screen
        If (Ball.Left < 0) Then
            HSpeed = -HSpeed
        End If

        ' Check bottom of screen (game over)
        If (Ball.Bottom > Me.ClientRectangle.Height) Then
            Timer1.Enabled = False
            LabelMessage.Text = "Game Over"
            My.Computer.Audio.Play(My.Resources.gameover, AudioPlayMode.Background)

            Dim result As MsgBoxResult = MsgBox("Play again?", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.No) Then
                Application.Exit()
            End If

            If (result = MsgBoxResult.Yes) Then
                Score = 0
                MakeBricks()
            End If
        End If

        Dim C As Single = Ball.Left + Ball.Width / 2
        ' Check for bat hit
        If (C > Bat.Left And C < Bat.Right And VSpeed > 0 And
            Ball.Bottom > Bat.Top And Ball.Top > Bat.Top) Then
            VSpeed = -VSpeed

            ' Curve the bat
            Dim offset As Single = (Ball.Left + Ball.Width / 2) - (Bat.Left + Bat.Width / 2)
            Dim ratio As Single = offset / (Bat.Width / 2)
            HSpeed += 2 * ratio
        End If

        ' Check right side of screen
        If Ball.Right > Me.ClientRectangle.Width Then
            HSpeed = -HSpeed
        End If

        For Each Cnt As Control In Me.Controls
            If Cnt.Name = "Brick" Then
                CheckBrick(Cnt, Ball)
            End If
        Next


        Ball.Left += HSpeed
        Ball.Top += VSpeed
    End Sub

    Private Sub CheckBrick(ByVal Brick As Button, ByVal Ball As Button)
        If Brick.Visible Then
            Dim Hit As Boolean = False
            Dim C As Single = Ball.Left + Ball.Width / 2

            ' Check bottom of brick for hit
            If (VSpeed < 0 And C > Brick.Left And C < Brick.Right And
                Ball.Top < Brick.Bottom And Ball.Bottom > Brick.Bottom) Then
                VSpeed = -VSpeed
                Hit = True
            End If

            ' Check top of brick for hit
            If (VSpeed > 0 And C > Brick.Left And C < Brick.Right And Ball.Bottom > Brick.Top And
                Ball.Top < Brick.Top) Then
                VSpeed = -VSpeed
                Hit = True
            End If

            C = Ball.Top + Ball.Height / 2
            ' Check left side of brick for hit
            If (HSpeed > 0 And C > Brick.Top And C < Brick.Bottom And
                Ball.Right > Brick.Left And Ball.Left < Brick.Left) Then
                HSpeed = -HSpeed
                Hit = True
            End If

            ' Check right side of brick for hit
            If (HSpeed < 0 And C > Brick.Top And C < Brick.Bottom And
                Ball.Left < Brick.Right And Ball.Right > Brick.Right) Then
                HSpeed = -HSpeed
                Hit = True
            End If

            If Hit Then
                Brick.Visible = False
                Score += Brick.Tag
                ' If the user gets to over 100pts, increase the difficulty by speeding up the ball
                If (Score > 100) Then
                    If (VSpeed < 0) Then VSpeed = -6
                    If (VSpeed > 0) Then VSpeed = 6
                Else
                    If (VSpeed < 0) Then VSpeed = -3
                    If (VSpeed > 0) Then VSpeed = 3
                End If
                LabelMessage.Text = Score.ToString
            End If
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ' Amp the difficulty when user gets to over 50pts by making the bat smaller 
        If (Score > 50) Then
            Bat.Width = 0.08 * Me.ClientRectangle.Width
        Else
            Bat.Width = 0.15 * Me.ClientRectangle.Width
        End If
        Bat.Height = 0.03 * Me.ClientRectangle.Height
        Bat.Top = 0.95 * Me.ClientRectangle.Height
        Bat.Left = e.X - (0.15 * Me.ClientRectangle.Width)
    End Sub

    Private Sub MakeBricks()

        ' Clear old bricks
        For i As Integer = Me.Controls.Count - 1 To 0 Step -1
            If (Me.Controls(i).Name = "Brick") Then
                Me.Controls.RemoveAt(i)
            End If
        Next

        ' Build the bricks 
        For R As Integer = 0 To Rows - 1
            For C As Integer = 0 To Cols - 1
                Dim B As New Button
                Me.Controls.Add(B)
                B.Visible = True
                B.Name = "Brick"
                B.Tag = Rows - R
                B.Width = Me.ClientRectangle.Width / Cols
                B.Height = Me.ClientRectangle.Height * RowHeight
                B.Left = C * B.Width
                B.Top = Me.ClientRectangle.Height * (TopRow + R * RowHeight)
                If (R = 0 Or R = 1) Then
                    B.BackColor = Color.Red
                ElseIf (R = 2 Or R = 3) Then
                    B.BackColor = Color.Orange
                ElseIf (R = 4 Or R = 5) Then
                    B.BackColor = Color.Green
                Else
                    B.BackColor = Color.Yellow
                End If
                B.FlatStyle = FlatStyle.Flat
            Next
        Next

        ' Position the ball in the form
        With Ball
            .Left = Me.ClientRectangle.Width / 2
            .Top = Me.ClientRectangle.Height * 0.9
            VSpeed = -3
            HSpeed = 1
        End With

        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        MakeBricks()
    End Sub


End Class
