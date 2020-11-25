
Public Class Trip
    Public auxstr(15) As String
    Public Property TripDate As Date
    Public Property TrainTrain As Train
    Public Property Prod As Product
    Public Property TonsTransported As Long
    Public Property auxCollection As Collection
    Public ReadOnly Property TripCollection As TripDAO

    Public Sub New()
        Me.TripCollection = New TripDAO
        auxCollection = New Collection
        auxstr = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
    End Sub

    Public Sub New(dt As Date, t As Train, p As Product)
        Me.TripCollection = New TripDAO
        Me.TripDate = dt
        Me.TrainTrain = t
        Me.Prod = p
        auxCollection = New Collection
        auxstr = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}

    End Sub

    Public Sub New(dt As Date, t As Train, p As Product, tons As Long)
        Me.TripCollection = New TripDAO
        Me.TripDate = dt
        Me.TrainTrain = t
        Me.Prod = p
        Me.TonsTransported = tons
        auxCollection = New Collection
        auxstr = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}

    End Sub

    Public Sub ReadAllTrips(path As String)
        Me.TripCollection.ReadAll(path)
    End Sub

    Public Sub ReadTrip()
        Me.TripCollection.Read(Me)
    End Sub

    Public Function InsertTrip() As Integer
        Return Me.TripCollection.Insert(Me)
    End Function
    Public Function UpdateTrip() As Integer
        Return Me.TripCollection.Update(Me)
    End Function

    Public Function DeleteTrip() As Integer
        Return Me.TripCollection.Delete(Me)
    End Function

    Public Sub RankingTrainsType(ByVal time1 As DateTime, ByRef time2 As DateTime)

        Me.TripCollection.GetRankingTrainsType(time1, time2)

    End Sub

    Public Sub RankingProducts(ByVal time1 As DateTime, ByRef time2 As DateTime)

        Me.TripCollection.GetRankingProducts(time1, time2)

    End Sub

    Public Sub TripsAndProducts(ByVal time1 As DateTime, ByRef time2 As DateTime, ByRef t As Train)

        Me.TripCollection.GetTripsAndProducts(time1, time2, t)

    End Sub
    Public Sub Profit()

        Me.TripCollection.GetProfit()

    End Sub

    Public Sub TotalProfit()

        Me.TripCollection.GetTotalProfit()

    End Sub
End Class

