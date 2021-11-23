<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Ball = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Bat = New System.Windows.Forms.Button()
        Me.LabelMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Ball
        '
        Me.Ball.BackColor = System.Drawing.Color.White
        Me.Ball.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ball.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Ball.Location = New System.Drawing.Point(217, 494)
        Me.Ball.Name = "Ball"
        Me.Ball.Size = New System.Drawing.Size(11, 11)
        Me.Ball.TabIndex = 0
        Me.Ball.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Bat
        '
        Me.Bat.BackColor = System.Drawing.Color.SteelBlue
        Me.Bat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bat.Location = New System.Drawing.Point(191, 511)
        Me.Bat.Name = "Bat"
        Me.Bat.Size = New System.Drawing.Size(65, 15)
        Me.Bat.TabIndex = 1
        Me.Bat.UseVisualStyleBackColor = False
        '
        'LabelMessage
        '
        Me.LabelMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelMessage.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMessage.ForeColor = System.Drawing.Color.White
        Me.LabelMessage.Location = New System.Drawing.Point(0, 0)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(481, 28)
        Me.LabelMessage.TabIndex = 2
        Me.LabelMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(481, 538)
        Me.Controls.Add(Me.LabelMessage)
        Me.Controls.Add(Me.Bat)
        Me.Controls.Add(Me.Ball)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Breakout"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ball As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Bat As Button
    Friend WithEvents LabelMessage As Label
End Class
