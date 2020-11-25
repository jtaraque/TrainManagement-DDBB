<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformation
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Profit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PriceProduct = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProductID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TripDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TripProduct = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TonsTransported = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrainID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonShowInformation = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PriceDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EurosPerTon = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Profit, Me.PriceProduct, Me.EurosPerTon, Me.PriceDate, Me.TripProduct, Me.TripDate, Me.TrainID, Me.ProductID, Me.TonsTransported})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(31, 34)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(855, 137)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Profit
        '
        Me.Profit.Text = "Profit"
        Me.Profit.Width = 68
        '
        'PriceProduct
        '
        Me.PriceProduct.Text = "PriceProduct"
        Me.PriceProduct.Width = 93
        '
        'ProductID
        '
        Me.ProductID.DisplayIndex = 2
        Me.ProductID.Text = "ProductID"
        Me.ProductID.Width = 78
        '
        'TripDate
        '
        Me.TripDate.DisplayIndex = 7
        Me.TripDate.Text = "TripDate"
        Me.TripDate.Width = 84
        '
        'TripProduct
        '
        Me.TripProduct.DisplayIndex = 6
        Me.TripProduct.Text = "TripProduct"
        Me.TripProduct.Width = 131
        '
        'TonsTransported
        '
        Me.TonsTransported.DisplayIndex = 5
        Me.TonsTransported.Text = "TonsTransported"
        Me.TonsTransported.Width = 89
        '
        'TrainID
        '
        Me.TrainID.DisplayIndex = 3
        Me.TrainID.Text = "TrainID"
        Me.TrainID.Width = 107
        '
        'ButtonShowInformation
        '
        Me.ButtonShowInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonShowInformation.Location = New System.Drawing.Point(339, 283)
        Me.ButtonShowInformation.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonShowInformation.Name = "ButtonShowInformation"
        Me.ButtonShowInformation.Size = New System.Drawing.Size(185, 89)
        Me.ButtonShowInformation.TabIndex = 1
        Me.ButtonShowInformation.Text = "Calculate"
        Me.ButtonShowInformation.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader2})
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(31, 179)
        Me.ListView2.Margin = New System.Windows.Forms.Padding(4)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(426, 95)
        Me.ListView2.TabIndex = 2
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Train"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "TripDate"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 0
        Me.ColumnHeader1.Text = "Total Profit"
        Me.ColumnHeader1.Width = 116
        '
        'PriceDate
        '
        Me.PriceDate.DisplayIndex = 4
        Me.PriceDate.Text = "PriceDate"
        Me.PriceDate.Width = 91
        '
        'EurosPerTon
        '
        Me.EurosPerTon.DisplayIndex = 8
        Me.EurosPerTon.Text = "EurosPerTon"
        '
        'FormInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 385)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.ButtonShowInformation)
        Me.Controls.Add(Me.ListView1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormInformation"
        Me.Text = "Information"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents Profit As ColumnHeader
    Friend WithEvents PriceProduct As ColumnHeader
    Friend WithEvents ProductID As ColumnHeader
    Friend WithEvents TripDate As ColumnHeader
    Friend WithEvents TripProduct As ColumnHeader
    Friend WithEvents ButtonShowInformation As Button
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Protected Friend WithEvents TonsTransported As ColumnHeader
    Friend WithEvents TrainID As ColumnHeader
    Friend WithEvents PriceDate As ColumnHeader
    Friend WithEvents EurosPerTon As ColumnHeader
End Class
