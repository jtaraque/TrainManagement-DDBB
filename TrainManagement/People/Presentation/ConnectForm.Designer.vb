<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectForm))
        Me.HelpLabel = New System.Windows.Forms.Label()
        Me.PathButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LabelPath = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HelpLabel
        '
        Me.HelpLabel.AutoSize = True
        Me.HelpLabel.Location = New System.Drawing.Point(12, 208)
        Me.HelpLabel.Name = "HelpLabel"
        Me.HelpLabel.Size = New System.Drawing.Size(249, 17)
        Me.HelpLabel.TabIndex = 11
        Me.HelpLabel.Text = "Select a valid database, then connect."
        '
        'PathButton
        '
        Me.PathButton.Location = New System.Drawing.Point(12, 237)
        Me.PathButton.Name = "PathButton"
        Me.PathButton.Size = New System.Drawing.Size(95, 58)
        Me.PathButton.TabIndex = 10
        Me.PathButton.Text = "Select Path"
        Me.PathButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(378, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(287, 286)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(103, 41)
        Me.CloseButton.TabIndex = 8
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'ConnectButton
        '
        Me.ConnectButton.Enabled = False
        Me.ConnectButton.Location = New System.Drawing.Point(127, 237)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(102, 58)
        Me.ConnectButton.TabIndex = 7
        Me.ConnectButton.Text = "Connect"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LabelPath
        '
        Me.LabelPath.AutoSize = True
        Me.LabelPath.Location = New System.Drawing.Point(12, 328)
        Me.LabelPath.Name = "LabelPath"
        Me.LabelPath.Size = New System.Drawing.Size(0, 17)
        Me.LabelPath.TabIndex = 12
        '
        'ConnectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(430, 354)
        Me.Controls.Add(Me.LabelPath)
        Me.Controls.Add(Me.HelpLabel)
        Me.Controls.Add(Me.PathButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Name = "ConnectForm"
        Me.Text = "ConnectForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HelpLabel As Label
    Friend WithEvents PathButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CloseButton As Button
    Friend WithEvents ConnectButton As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents LabelPath As Label
End Class
