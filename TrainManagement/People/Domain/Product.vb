Public Class Product
    Public Property ProductID As Long
    Public Property ProductDescription As String
    Public ReadOnly Property Products As ProductDAO

    Public Sub New()
        Me.Products = New ProductDAO()
    End Sub

    Public Sub New(ByVal ProductID As Long)
        Me.ProductID = ProductID
        Me.Products = New ProductDAO()
    End Sub

    Public Sub New(ByVal ProductID As Long, ByVal ProductDescription As String)
        Me.ProductID = ProductID
        Me.ProductDescription = ProductDescription
        Me.Products = New ProductDAO()
    End Sub

    Public Sub New(ByVal ProductDescription As String)
        Me.ProductDescription = ProductDescription
        Me.Products = New ProductDAO()
    End Sub



    Public Function DeleteProduct() As Integer
        Return Me.Products.Delete(Me)
    End Function



    Public Function InsertProduct() As Integer
        Return Me.Products.Insert(Me)
    End Function



    Public Sub ReadProduct()
        Me.Products.Read(Me)
    End Sub



    Public Function UpdateProduct() As Integer
        Return Me.Products.Update(Me)
    End Function



    Public Sub ReadAllProducts(path As String)
        Me.Products.ReadAll(path)
    End Sub
End Class