Public Class TrainType

    Public Property TrainTypeID As Long
    Public Property Description As String
    Public Property MaxCapacity As Long
    Public ReadOnly Property TTypeDAO As TrainTypeDAO

    Public Sub New()
        Me.TTypeDAO = New TrainTypeDAO
    End Sub

    Public Sub New(id As Long)
        Me.TTypeDAO = New TrainTypeDAO
        Me.TrainTypeID = id
    End Sub

    Public Sub New(Description As String, MaxCapacity As Long)
        Me.TTypeDAO = New TrainTypeDAO
        Me.Description = Description
        Me.MaxCapacity = MaxCapacity
    End Sub

    Public Sub New(TrainTypeID As Long, Description As String, MaxCapacity As Long)
        Me.TTypeDAO = New TrainTypeDAO
        Me.Description = Description
        Me.MaxCapacity = MaxCapacity
        Me.TrainTypeID = TrainTypeID
    End Sub

    Public Sub ReadAllTrainTypes(path As String)
        Me.TTypeDAO.ReadAll(path)
    End Sub

    Public Sub ReadTrainType()
        Me.TTypeDAO.Read(Me)
    End Sub

    Public Function InsertTrainType() As Integer
        Return Me.TTypeDAO.Insert(Me)
    End Function

    Public Function UpdateTrainType() As Integer
        Return Me.TTypeDAO.Update(Me)
    End Function

    Public Function DeleteTrainType() As Integer
        Return Me.TTypeDAO.Delete(Me)
    End Function

End Class
