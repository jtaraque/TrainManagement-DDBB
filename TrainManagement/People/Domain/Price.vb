Public Class Price

    Public Property Product As Product
    Public Property PriceDate As Date
    Public Property EurosPerTon As Double
    Public ReadOnly Property PriDAO As PricesDAO

    Public Sub New()
        Me.PriDAO = New PricesDAO
    End Sub

    Public Sub New(id As Product)
        Me.Product = id
        Me.PriDAO = New PricesDAO
    End Sub

    Public Sub New(id As Product, PriceDate As DateTime)
        Me.Product = id
        Me.PriceDate = PriceDate
        Me.PriDAO = New PricesDAO
    End Sub

    Public Sub New(id As Product, PriceDate As DateTime, EurosPerTon As Double)
        Me.Product = id
        Me.PriceDate = PriceDate
        Me.EurosPerTon = EurosPerTon
        Me.PriDAO = New PricesDAO
    End Sub

    Public Sub ReadAllPrices(path As String)
        Me.PriDAO.ReadAll(path)
    End Sub

    Public Sub ReadPrice()
        Me.PriDAO.Read(Me)
    End Sub

    Public Function InsertPrice() As Integer
        Return Me.PriDAO.Insert(Me)
    End Function

    Public Function UpdatePrice() As Integer
        Return Me.PriDAO.Update(Me)
    End Function

    Public Function DeletePrice() As Integer
        Return Me.PriDAO.Delete(Me)
    End Function

End Class