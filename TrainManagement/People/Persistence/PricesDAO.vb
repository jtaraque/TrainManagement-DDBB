Public Class PricesDAO

    Public ReadOnly Property Prices As Collection

    Public Sub New()
        Me.Prices = New Collection
    End Sub

    Public Sub ReadAll(path As String)
        Dim p As Price
        Dim col, aux As Collection
        col = DBBroker.GetBroker(path).Read("SELECT * FROM Prices ORDER BY Product")
        For Each aux In col

            p = New Price(New Product(Long.Parse(aux(1).ToString)), Date.Parse(aux(2).ToString))
            p.ReadPrice()
            Me.Prices.Add(p)
        Next
    End Sub

    Public Sub Read(ByRef p As Price)
        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT * FROM Prices WHERE Product=" & p.Product.ProductID & " AND PriceDate= #" & p.PriceDate.ToString("MM/dd/yyyy hh: mm : ss") & "#;")
        For Each aux In col
            p.Product.ProductID = (Long.Parse(aux(1).ToString))
            p.PriceDate = Date.Parse(aux(2).ToString)
            p.EurosPerTon = Double.Parse(aux(3).ToString)
        Next
    End Sub

    Public Function Insert(ByVal p As Price) As Integer
        Return DBBroker.GetBroker.Change("INSERT INTO Prices (Product,PriceDate, EurosPerTon) VALUES (" & p.Product.ProductID & ", #" & p.PriceDate.ToString("MM/dd/yyyy hh: mm : ss") & "#,'" & p.EurosPerTon.ToString("######.## €") & "');")
    End Function

    Public Function Update(ByVal p As Price) As Integer
        Return DBBroker.GetBroker.Change("UPDATE Prices SET EurosPerTon =" & p.EurosPerTon & " WHERE Product=" & p.Product.ProductID & " AND PriceDate= #" & p.PriceDate.ToString("MM/dd/yyyy hh: mm : ss") & "#;")
    End Function

    Public Function Delete(ByVal p As Price) As Integer
        Return DBBroker.GetBroker.Change("DELETE FROM Prices WHERE Product=" & p.Product.ProductID & " AND PriceDate= #" & p.PriceDate.ToString("MM/dd/yyyy hh: mm : ss") & "#;")
    End Function

End Class