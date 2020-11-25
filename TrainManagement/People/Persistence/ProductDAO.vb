Public Class ProductDAO
    Public ReadOnly Property ProductList As Collection
    Public Sub New()
        Me.ProductList = New Collection
    End Sub
    Public Function Insert(ByRef p As Product) As Integer

        Return DBBroker.GetBroker().Change("INSERT INTO Products (ProductDescription) VALUES ('" & p.ProductDescription & "');")

    End Function

    Public Function Delete(ByRef p As Product) As Integer

        Return DBBroker.GetBroker().Change("DELETE FROM Products WHERE ProductID=" & p.ProductID & ";")

    End Function

    Public Function Update(ByRef p As Product) As Integer

        Return DBBroker.GetBroker().Change("UPDATE Products SET ProductDescription='" & p.ProductDescription & "' WHERE ProductID =" & p.ProductID & ";")

    End Function

    Public Sub Read(ByRef p As Product)
        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT * FROM Products WHERE ProductID=" & p.ProductID & ";")
        For Each aux In col
            p.ProductID = Long.Parse(aux(1).ToString)
            p.ProductDescription = aux(2).ToString
        Next
    End Sub

    Public Sub ReadAll(path As String)
        Dim p As Product
        Dim col, aux As Collection
        col = DBBroker.GetBroker(path).Read("SELECT * FROM Products ORDER BY ProductID")
        For Each aux In col
            p = New Product(Long.Parse(aux(1).ToString))
            Me.ProductList.Add(p)
        Next
    End Sub
End Class