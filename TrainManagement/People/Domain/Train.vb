Public Class Train

    Public Property TrainID As String
    Public Property TrainType As TrainType
    Public ReadOnly Property TraDAO As TrainDAO

    Public Sub New()
        Me.TraDAO = New TrainDAO
        Me.TrainType = New TrainType
    End Sub

    Public Sub New(id As String)
        Me.TraDAO = New TrainDAO
        Me.TrainID = id
        Me.TrainType = New TrainType()
    End Sub

    Public Sub New(id As String, tt As TrainType)
        Me.TraDAO = New TrainDAO
        Me.TrainID = id
        Me.TrainType = tt
        TrainType.ReadTrainType()
    End Sub

    Public Sub ReadAllTrains(path As String)
        Me.TraDAO.ReadAll(path)
    End Sub

    Public Sub ReadTrain()
        Me.TraDAO.Read(Me)
        Me.TrainType.ReadTrainType()
    End Sub

    Public Function InsertTrain() As Integer
        Return Me.TraDAO.Insert(Me)
    End Function

    Public Function UpdateTrain() As Integer
        Return Me.TraDAO.Update(Me)
    End Function

    Public Function DeleteTrain() As Integer
        Return Me.TraDAO.Delete(Me)
    End Function

End Class
