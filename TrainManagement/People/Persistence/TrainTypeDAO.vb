Public Class TrainTypeDAO

    Public ReadOnly Property TrainTypes As Collection

    Public Sub New()
        Me.TrainTypes = New Collection
    End Sub

    Public Sub ReadAll(path As String)
        Dim type As TrainType
        Dim col, aux As Collection
        col = DBBroker.GetBroker(path).Read("SELECT * FROM TrainTypes ORDER BY TrainTypeID")
        For Each aux In col
            type = New TrainType(Long.Parse(aux(1).ToString))
            Me.TrainTypes.Add(type)
        Next
    End Sub

    Public Sub Read(ByRef type As TrainType)
        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT * FROM TrainTypes WHERE TrainTypeID=" & type.TrainTypeID & ";")
        For Each aux In col
            type.TrainTypeID = Long.Parse(aux(1).ToString)
            type.Description = aux(2).ToString
            type.MaxCapacity = Long.Parse(aux(3).ToString)
        Next
    End Sub

    Public Function Insert(ByVal type As TrainType) As Integer
        Return DBBroker.GetBroker.Change("INSERT INTO TrainTypes (TrainTypeDescription,MaxCapacity) VALUES ('" & type.Description & "', " & type.MaxCapacity & ");")
    End Function

    Public Function Update(ByVal type As TrainType) As Integer
        Return DBBroker.GetBroker.Change("UPDATE TrainTypes SET TrainTypeDescription='" & type.Description & "', MaxCapacity =" & type.MaxCapacity & " WHERE TrainTypeID=" & type.TrainTypeID & ";")
    End Function

    Public Function Delete(ByVal type As TrainType) As Integer
        Return DBBroker.GetBroker.Change("DELETE FROM TrainTypes WHERE TrainTypeID=" & type.TrainTypeID & ";")
    End Function

End Class
