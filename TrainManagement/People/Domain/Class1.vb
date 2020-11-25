Public Class Product
    Public Property ProductID As Long
    Public Property ProductDescription As String
    Public Property Products As ProductDAO



    Public Sub New(ByVal ProductID As Long, ByVal ProductDescription As String)
        Me.ProductID = ProductID
        Me.ProductDescription = ProductDescription
        Me.Products = New ProductDAO()
    End Sub



    Public Function deleteProduct() As Integer
        Dim resul As Integer
        resul = Products.delete(Me)
        Return resul
    End Function



    Public Function insertProduct() As Integer
        Dim result As Integer = 0
        Dim trainAux As Train
        result = Products.insert_Booking(Me)
        If result = 1 Then
            Products.search_BookingID(Me)
            For Each trainAux In Me.Train
                Products.insert_Trips(Me, trainAux)
            Next
        End If



        Return result
    End Function



    Public Sub readProduct()
        Products.read_Products(Me)
        Products.read_Trips(Me)
    End Sub



    Public Sub readallProducts(ByVal path As String)
        Products.Readall(path)
    End Sub



End Class