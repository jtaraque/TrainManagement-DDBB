Public Class FormRankingTypeTrains


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim BeginDate As Date = Date.Parse(DateTimePicker1.Value.ToShortDateString)
            Dim EndDate As Date = Date.Parse(DateTimePicker2.Value.ToShortDateString)
            Dim tr As New Trip
            tr.RankingTrainsType(BeginDate, EndDate)
            Dim trAux As Trip
            Dim tAux As Train
            ListView1.Items.Clear()
            Dim lsvitem As ListViewItem = New ListViewItem()
            For Each trAux In tr.TripCollection.Trips
                For Each tAux In trAux.auxCollection
                    lsvitem = ListView1.Items.Add(tAux.TrainID)
                    lsvitem.SubItems.Add(tAux.TrainType.TrainTypeID.ToString)
                    ListView1.Update()
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
End Class