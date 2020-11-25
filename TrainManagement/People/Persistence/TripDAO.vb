Public Class TripDAO

    Public ReadOnly Property Trips As Collection

    Public Sub New()
        Me.Trips = New Collection
    End Sub

    Public Sub ReadAll(path As String)
        Dim t As Trip
        Dim col, aux As Collection
        col = DBBroker.GetBroker(path).Read("SELECT * FROM Trips ORDER BY TripDate")
        For Each aux In col
            Dim taux As New Train(aux(2).ToString)
            taux.ReadTrain()
            Dim paux As New Product(Long.Parse(aux(3).ToString))
            paux.ReadProduct()
            t = New Trip(Date.Parse(aux(1).ToString), taux, paux, Long.Parse(aux(4).ToString))
            Me.Trips.Add(t)
        Next
    End Sub

    Public Sub Read(ByRef t As Trip)
        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT * FROM Trips WHERE TripDate= '#" & t.TripDate.ToString("MM/dd/yyyy hh: mm : ss") & "#' AND Train='" & t.TrainTrain.TrainID & "' AND Product =" & t.Prod.ProductID & ";")
        For Each aux In col
            t.TripDate = Date.Parse(aux(1).ToString)
            t.TrainTrain.ReadTrain()
            t.Prod.ReadProduct()
            t.TonsTransported = Long.Parse(aux(4).ToString)

        Next
    End Sub

    Public Function Insert(ByVal t As Trip) As Integer
        Return DBBroker.GetBroker.Change("INSERT INTO Trips VALUES (#" & t.TripDate.ToString("MM/dd/yyyy hh: mm : ss") & "#,'" & t.TrainTrain.TrainID & "'," & t.Prod.ProductID & "," & t.TonsTransported & ");")
    End Function

    Public Function Update(ByVal t As Trip) As Integer
        Return DBBroker.GetBroker.Change("UPDATE Trips SET TonsTransported =" & t.TonsTransported & " WHERE TripDate= #" & t.TripDate.ToString("MM/dd/yyyy hh: mm : ss") & "# AND Train='" & t.TrainTrain.TrainID & "' AND Product =" & t.Prod.ProductID & ";")
    End Function

    Public Function Delete(ByVal t As Trip) As Integer
        Return DBBroker.GetBroker.Change("DELETE FROM Trips WHERE TripDate= #" & t.TripDate.ToString("MM/dd/yyyy hh: mm : ss") & "# AND Train='" & t.TrainTrain.TrainID & "' AND Product =" & t.Prod.ProductID & ";")
    End Function

    Public Sub GetRankingTrainsType(ByVal time1 As DateTime, ByVal time2 As DateTime)
        Dim tr As Trip
        Dim t As Train

        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT COUNT(TrainType),TrainType From Trips INNER JOIN Trains On Trips.Train = Trains.TrainID WHERE TripDate BETWEEN #" & time1.ToString("MM/dd/yyyy hh:mm:ss") & "# AND #" & time2.ToString("MM/dd/yyyy hh:mm:ss") & "# GROUP BY TrainType ORDER BY COUNT(TrainType) DESC;")
        For Each aux In col
            tr = New Trip
            t = New Train
            t.TrainID = aux(1).ToString
            t.TrainType.TrainTypeID = Long.Parse(aux(2).ToString)
            tr.auxCollection.Add(t)
            Me.Trips.Add(tr)
        Next
    End Sub

    Public Sub GetRankingProducts(ByVal time1 As DateTime, ByVal time2 As DateTime)
        Dim tr As Trip
        Dim p As Product

        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT COUNT(ProductID),ProductID From Trips INNER JOIN Products On Trips.Product = Products.ProductID WHERE TripDate BETWEEN #" & time1.ToString("MM/dd/yyyy hh:mm:ss") & "# AND #" & time2.ToString("MM/dd/yyyy hh:mm:ss") & "# GROUP BY ProductID ORDER BY COUNT(ProductID) DESC;")
        For Each aux In col
            tr = New Trip
            p = New Product
            p.ProductID = Long.Parse(aux(1).ToString)
            p.ProductDescription() = aux(2).ToString
            tr.auxCollection.Add(p)
            Me.Trips.Add(tr)
        Next
    End Sub

    Public Sub GetTripsAndProducts(ByVal time1 As DateTime, ByVal time2 As DateTime, ByRef train As Train)
        Dim tr As Trip
        Dim t As Train

        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT TripDATE, Product FROM Trips WHERE TripDate BETWEEN #" & time1.ToString("MM/dd/yyyy hh:mm:ss") & "# AND #" & time2.ToString("MM/dd/yyyy hh:mm:ss") & "# AND Train ='" & train.TrainID & "';")
        For Each aux In col
            tr = New Trip
            t = New Train
            t.TrainID = aux(1).ToString
            t.TrainType.TrainTypeID = Long.Parse(aux(2).ToString)
            tr.auxCollection.Add(t)
            Me.Trips.Add(tr)
        Next
    End Sub

    Public Sub GetProfit()
        Dim tr As Trip
        Dim col As Collection : Dim aux As Collection

        col = DBBroker.GetBroker.Read("SELECT Prices.Product, Prices.EurosPerTon, Prices.PriceDate, Products.ProductID, Trips.TripDate, Trips.Train, Trips.Product, Trips.TonsTransported, Prices.EurosPerTon*Trips.TonsTransported FROM ((Products INNER JOIN Prices ON Products.ProductID = Prices.Product) INNER JOIN Trips ON Products.ProductID = Trips.Product) WHERE (((Trips.TripDate)=Prices.PriceDate) AND Prices.Product = Products.ProductID) GROUP BY Prices.Product,Prices.EurosPerTon, Prices.PriceDate,Products.ProductID,Trips.TripDate,trips.train,trips.product,Trips.tonstransported ORDER BY Prices.EurosPerTon*Trips.TonsTransported;")
        For Each aux In col
            tr = New Trip
            tr.auxstr(0) = aux(1).ToString 'Prices.Product
            tr.auxstr(1) = aux(2).ToString 'Prices.EurosPerTon
            tr.auxstr(2) = aux(3).ToString 'Prices.PriceDate
            tr.auxstr(3) = aux(4).ToString 'Products.ProductID
            tr.auxstr(4) = aux(5).ToString 'Trips.TripDate
            tr.auxstr(5) = aux(6).ToString 'Trips.Train
            tr.auxstr(6) = aux(7).ToString 'Trips.Product
            tr.auxstr(7) = aux(8).ToString 'Trips.TonsTransported
            tr.auxstr(8) = aux(9).ToString 'Prices.EurosPerTon*Trips.TonsTransported

            Me.Trips.Add(tr)
        Next
    End Sub

    Public Sub GetTotalProfit()
        Dim tr As Trip


        Dim col As Collection : Dim aux As Collection

        col = DBBroker.GetBroker.Read("SELECT TOP 1 Sum(Prices.EurosPerTon*Trips.TonsTransported),TripDate,Trips.Train FROM Trains INNER JOIN ((Products INNER JOIN Prices ON Products.ProductID = Prices.Product) INNER JOIN Trips ON Products.ProductID = Trips.Product) ON Trains.TrainID = Trips.Train WHERE (((Trips.TripDate)=Prices.PriceDate)) Group By Tripdate,Trips.Train")
        For Each aux In col
            tr = New Trip
            tr.auxstr(0) = aux(1).ToString 'Sum(Prices.EurosPerTon*Trips.TonsTransported)
            tr.auxstr(1) = aux(2).ToString 'TripDate
            tr.auxstr(2) = aux(3).ToString 'Trips.Train

            Me.Trips.Add(tr)
        Next
    End Sub
End Class
