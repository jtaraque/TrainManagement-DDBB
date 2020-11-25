Public Class FormInformation
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ButtonShowInformation_Click(sender As Object, e As EventArgs) Handles ButtonShowInformation.Click
        Try
            Dim t As New Trip
            t.Profit()
            Dim tr As Trip
            ListView1.Items.Clear()
            Dim lsvitem As ListViewItem = New ListViewItem()
            For Each tr In t.TripCollection.Trips
                lsvitem = ListView1.Items.Add(tr.auxstr(8))
                lsvitem.SubItems.Add(tr.auxstr(0))
                lsvitem.SubItems.Add(tr.auxstr(1))
                lsvitem.SubItems.Add(tr.auxstr(2))
                lsvitem.SubItems.Add(tr.auxstr(3))
                lsvitem.SubItems.Add(tr.auxstr(4))
                lsvitem.SubItems.Add(tr.auxstr(5))
                lsvitem.SubItems.Add(tr.auxstr(6))
                lsvitem.SubItems.Add(tr.auxstr(7))
                lsvitem.SubItems.Add(tr.auxstr(9))


                ListView1.Update()
            Next


            Dim t2 As New Trip
            t2.TotalProfit()
            Dim tr2 As Trip
            ListView2.Items.Clear()
            Dim lsvitem2 As ListViewItem = New ListViewItem()
            For Each tr2 In t2.TripCollection.Trips
                lsvitem2 = ListView2.Items.Add(tr2.auxstr(0))
                lsvitem2.SubItems.Add(tr2.auxstr(1))
                lsvitem2.SubItems.Add(tr2.auxstr(2))
                ListView2.Update()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Exit Sub
        End Try
    End Sub
End Class