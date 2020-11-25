Public Class FormTripsAndProducts
    Shared dbpath As String = System.IO.Path.GetFullPath(ConnectForm.OpenFileDialog1.FileName)
    Private Sub FormTripsAndProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t As New Train()
        Dim tAux As New Train()
        t.ReadAllTrains(dbpath)
        TextBox1.Enabled = False
        For Each tAux In t.TraDAO.Trains
            Me.ListBox1.Items.Add(tAux.TrainID)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        TextBox1.Text = Me.ListBox1.SelectedItem.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim BeginDate As Date = Date.Parse(DateTimePicker1.Value.ToShortDateString)
            Dim EndDate As Date = Date.Parse(DateTimePicker2.Value.ToShortDateString)
            Dim tr As New Trip
            Dim t As New Train(TextBox1.Text)
            t.ReadTrain()
            tr.TripsAndProducts(BeginDate, EndDate, t)
            Dim trAux As Trip
            Dim tAux As Train
            ListView1.Items.Clear()
            Dim counter As Integer = 0
            Dim s As String = ""
            Dim lsvitem As ListViewItem = New ListViewItem()
            For Each trAux In tr.TripCollection.Trips
                For Each tAux In trAux.auxCollection
                    lsvitem = ListView1.Items.Add(tAux.TrainID)
                    lsvitem.SubItems.Add(tAux.TrainType.TrainTypeID.ToString)
                    If Not ListView1.Items.ContainsKey(tAux.TrainID) Then
                        counter += 1

                    End If


                    ListView1.Update()
                    s += tAux.TrainType.TrainTypeID.ToString + ","
                Next
            Next

            lsvitem = ListView1.Items.Add("Total:" + counter.ToString)
            lsvitem.SubItems.Add(s)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
End Class