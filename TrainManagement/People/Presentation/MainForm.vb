Public Class MainForm
    Shared dbpath As String = System.IO.Path.GetFullPath(ConnectForm.OpenFileDialog1.FileName)
    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButtonTrains.Click
        Try
            Dim tp As TrainType
            tp = New TrainType(Long.Parse(TextBoxTrainType.Text))
            Dim train As Train = New Train(TextBoxTrainID.Text, tp)

            If train.InsertTrain() = 1 Then
                Me.ClearButtonTrains.PerformClick()

                TabControl1.SelectedIndex = 1
                TabControl1.SelectedIndex = 0
                MessageBox.Show("Train ID inserted correctly", "Train", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ClearButtonTrains.Click
        TextBoxTrainID.Text = ""
        TextBoxTrainType.Text = ""
        TextBoxTrainID.Enabled = True
        InsertButtonTrains.Enabled = True
        ListBoxTrains.SelectedIndex = -1
        ListBoxTrainsTTypes.SelectedIndex = -1
        ListBoxTrainsTTypes.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ClearButtonProducts.Click
        TextBoxProductDescription.Text = ""
        TextBoxProductID.Text = ""
        InsertButtonProducts.Enabled = True
        ListBoxProducts.SelectedIndex = -1
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles ClearButtonPrices.Click
        TextBoxPriceProduct.Text = ""
        TextBoxPriceEurosTon.Text = ""
        DateTimePicker2.Value() = #1/1/1970 12:00:00 AM#
        DateTimePicker2.Enabled = True
        InsertButtonPrices.Enabled = True
        ListBoxPrices.SelectedIndex = -1
        ListBoxPricesProduct.SelectedIndex = -1

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles ClearButtonTTypes.Click
        TextBoxTrainTypeMaxCapacity.Text = ""
        TextBoxTrainTypeDescription.Text = ""
        TextBoxTrainTypeID.Text = ""
        InsertButtonTTypes.Enabled = True
        ListBoxTTypes.SelectedIndex = -1

    End Sub

    Private Sub ClearButton_Trips(sender As Object, e As EventArgs) Handles ClearButtonTrips.Click
        TextBoxTripsTrain.Text = ""
        TextBoxTripsTons.Text = ""
        TextBoxTripsProduct.Text = ""
        InsertButtonTrips.Enabled = True
        ListBoxTripsProduct.Enabled = True
        ListBoxTripsTrains.Enabled = True
        DateTimePicker1.ResetText()
        DateTimePicker1.Enabled = True
        ListBoxTripsProduct.SelectedIndex = -1
        ListBoxTripsTrains.SelectedIndex = -1
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles InsertButtonTTypes.Click
        Try
            Dim Description As String = Me.TextBoxTrainTypeDescription.Text
            Dim Capacity As Long = Long.Parse(Me.TextBoxTrainTypeMaxCapacity.Text)

            Dim traintype As TrainType = New TrainType(Description, Capacity)

            If traintype.InsertTrainType() = 1 Then
                Me.ClearButtonTTypes.PerformClick()

                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 3
                MessageBox.Show("Train Type correctly inserted", "Train Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles InsertButtonProducts.Click
        Try
            Dim Description As String = Me.TextBoxProductDescription.Text
            Dim product As Product = New Product(Description)

            If product.InsertProduct() = 1 Then
                Me.ClearButtonProducts.PerformClick()
                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 1
                MessageBox.Show("Product inserted correclty", "Product", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles InsertButtonPrices.Click
        Try

            Dim p As New Product(Long.Parse(Me.TextBoxPriceProduct.Text))
            p.ReadProduct()
            Dim PriceDate As DateTime = Date.Parse(DateTimePicker2.Value.ToShortDateString)
            Dim EurosPerTon As Double = Double.Parse(Me.TextBoxPriceEurosTon.Text)
            Dim price As Price = New Price(p, PriceDate, EurosPerTon)

            If price.InsertPrice() = 1 Then
                Me.ClearButtonPrices.PerformClick()
                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 2

                MessageBox.Show("Product introduced correctly", "Product", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles InsertButtonTrips.Click
        Try
            Dim TripDate As Date = Date.Parse(DateTimePicker1.Value.ToShortDateString)
            Dim t2 As New Train(Me.TextBoxTripsTrain.Text)
            t2.ReadTrain()
            Dim ProductsSelected As New Collection
            Dim productcount As Integer = (ListBoxTripsProduct.SelectedItems.Count - 1)

            If (Long.Parse(TextBoxTripsTons.Text) * (productcount + 1) > t2.TrainType.MaxCapacity) Then
                MessageBox.Show("This train have a max capacity of " + t2.TrainType.MaxCapacity.ToString + ". And you are trying to insert " + (Long.Parse(TextBoxTripsTons.Text) * (productcount + 1)).ToString + " tons!", "Wrong tons selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim tons As Long = Long.Parse(Me.TextBoxTripsTons.Text)



                For i = 0 To productcount
                    ProductsSelected.Add(ListBoxTripsProduct.SelectedItems(i))
                Next
                Dim counter As Integer = 0
                For Each counter In ProductsSelected
                    Dim pAux As New Product(counter)
                    Dim trip As New Trip(TripDate, t2, pAux, tons)



                    If trip.InsertTrip() = 1 Then
                        Me.ClearButtonTrips.PerformClick()
                        TabControl1.SelectedIndex = 0
                        TabControl1.SelectedIndex = 4
                        MessageBox.Show("Trip introduced correctly", "Trip", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                Next
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub DeleteButtonTrains_Click(sender As Object, e As EventArgs) Handles DeleteButtonTrains.Click
        Try
            Dim t As New Train(TextBoxTrainID.Text)
            If t.DeleteTrain() = 1 Then
                Me.ClearButtonTrains.PerformClick()

                TabControl1.SelectedIndex = 1
                TabControl1.SelectedIndex = 0
                MessageBox.Show("Train has been deleted", "Train", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub ListBoxTrains_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxTrains.SelectedIndexChanged
        If ListBoxTrains.SelectedItem IsNot Nothing Then
            Dim id As String = ListBoxTrains.SelectedItem.ToString
            Dim t As New Train(id)
            t.ReadTrain()
            TextBoxTrainID.Text = t.TrainID
            Me.ListBoxTrainsTTypes.SelectedItem = t.TrainType.TrainTypeID
            TextBoxTrainID.Enabled = False
            InsertButtonTrains.Enabled = True
            UpdateButtonTrains.Enabled = True
            DeleteButtonTrains.Enabled = True
            ListBoxTrainsTTypes.Enabled = False
            InsertButtonTrains.Enabled = False

        End If
    End Sub

    Private Sub ListBoxTrainsTTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxTrainsTTypes.SelectedIndexChanged
        If ListBoxTrainsTTypes.SelectedItem IsNot Nothing Then
            Dim id As Long = Long.Parse(ListBoxTrainsTTypes.SelectedItem.ToString)
            Dim tt As New TrainType(id)
            tt.ReadTrainType()
            Me.TextBoxTrainType.Text = tt.TrainTypeID.ToString
        End If
    End Sub

    Private Sub ListBoxProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxProducts.SelectedIndexChanged
        If ListBoxProducts.SelectedItem IsNot Nothing Then
            Dim id As Long = Long.Parse(ListBoxProducts.SelectedItem.ToString)
            Dim p As New Product(id)
            p.ReadProduct()
            TextBoxProductID.Text = p.ProductID.ToString
            TextBoxProductDescription.Text = p.ProductDescription
            TextBoxProductID.Enabled = False
            InsertButtonProducts.Enabled = False
            UpdateButtonProducts.Enabled = True
            DeleteButtonProducts.Enabled = True

        End If
    End Sub

    Private Sub ListBoxPrices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxPrices.SelectedIndexChanged
        If ListBoxPrices.SelectedItem IsNot Nothing Then
            Dim id As Long = Long.Parse(ListBoxPricesProduct.SelectedItem.ToString)
            Dim prod As New Product(id)
            prod.ReadProduct()
            Dim pricedate As Date = Date.Parse(ListBoxPrices.SelectedItem.ToString)
            Dim pric As New Price(prod, pricedate)
            pric.ReadPrice()
            DateTimePicker2.Value = pricedate
            DateTimePicker2.Enabled = False
            TextBoxPriceEurosTon.Text = pric.EurosPerTon.ToString
            UpdateButtonPrices.Enabled = True
            DeleteButtonPrices.Enabled = True
            InsertButtonPrices.Enabled = False

        End If
    End Sub

    Private Sub ListBoxTTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxTTypes.SelectedIndexChanged
        If ListBoxTTypes.SelectedItem IsNot Nothing Then
            Dim id As Long = Long.Parse(ListBoxTTypes.SelectedItem.ToString)
            Dim tt As New TrainType(id)
            tt.ReadTrainType()
            TextBoxTrainTypeID.Text = tt.TrainTypeID.ToString
            TextBoxTrainTypeDescription.Text = tt.Description
            TextBoxTrainTypeMaxCapacity.Text = tt.MaxCapacity.ToString
            TextBoxTrainTypeID.Enabled = False
            InsertButtonTTypes.Enabled = False
            UpdateButtonTTypes.Enabled = True
            DeleteButtonTTypes.Enabled = True



        End If
    End Sub

    Private Sub MyTabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Select Case TabControl1.SelectedIndex
            Case 0
                TextBoxTrainID.Text = ""
                TextBoxTrainType.Text = ""
                TextBoxTrainID.Enabled = True
                ListBoxTrainsTTypes.Enabled = True
                ListBoxTrains.Items.Clear()
                Me.ListBoxTrainsTTypes.Items.Clear()
                TextBoxTrainType.Enabled = False
                Dim t As New Train()
                Dim tAux As New Train()
                Dim tt As New TrainType()
                Dim ttAux As New TrainType()
                t.ReadAllTrains(dbpath)
                tt.ReadAllTrainTypes(dbpath)

                For Each tAux In t.TraDAO.Trains
                    Me.ListBoxTrains.Items.Add(tAux.TrainID)
                Next
                For Each ttAux In tt.TTypeDAO.TrainTypes
                    Me.ListBoxTrainsTTypes.Items.Add(ttAux.TrainTypeID)
                Next
            Case 1
                TextBoxProductDescription.Text = ""
                TextBoxProductID.Text = ""
                TextBoxProductID.Enabled = False
                ListBoxProducts.Items.Clear()
                InsertButtonPrices.Enabled = True
                Dim p As New Product
                Dim pAux As New Product
                p.ReadAllProducts(dbpath)

                For Each pAux In p.Products.ProductList
                    Me.ListBoxProducts.Items.Add(pAux.ProductID)
                Next
            Case 2
                TextBoxPriceProduct.Text = ""
                TextBoxPriceEurosTon.Text = ""
                DateTimePicker2.Value = #01/01/1970#
                ListBoxPricesProduct.Items.Clear()
                Me.ListBoxPrices.Items.Clear()
                InsertButtonPrices.Enabled = True
                Dim p As New Product()
                Dim pAux As New Product()
                p.ReadAllProducts(dbpath)

                For Each pAux In p.Products.ProductList
                    Me.ListBoxPricesProduct.Items.Add(pAux.ProductID)
                Next
            Case 3
                ListBoxTTypes.Items.Clear()
                TextBoxTrainTypeDescription.Text = ""
                TextBoxTrainTypeMaxCapacity.Text = ""
                TextBoxTrainTypeID.Text = ""
                Dim ty As New TrainType
                Dim tyAux As New TrainType
                ty.ReadAllTrainTypes(dbpath)

                For Each tyAux In ty.TTypeDAO.TrainTypes
                    Me.ListBoxTTypes.Items.Add(tyAux.TrainTypeID)
                Next
                TextBoxTrainTypeID.Enabled = False

            Case 4
                Dim lsvitem As ListViewItem = New ListViewItem()
                Dim tr As New Trip
                Dim trAux As Trip
                tr.ReadAllTrips(dbpath)
                InsertButtonTrips.Enabled = True

                ListViewTrips.BeginUpdate()
                ListViewTrips.Items.Clear()
                For Each trAux In tr.TripCollection.Trips
                    lsvitem = ListViewTrips.Items.Add(trAux.TripDate.ToShortDateString)
                    lsvitem.SubItems.Add(trAux.TrainTrain.TrainID)
                    lsvitem.SubItems.Add(trAux.Prod.ProductID.ToString)
                    lsvitem.SubItems.Add(trAux.TonsTransported.ToString)
                    ListViewTrips.Update()
                Next

                ListViewTrips.EndUpdate()
                ListBoxTripsTrains.Items.Clear()
                ListBoxTripsProduct.Items.Clear()
                Dim t As New Train()
                Dim tAux As New Train()
                Dim p As New Product()
                Dim pAux As New Product()
                t.ReadAllTrains(dbpath)
                p.ReadAllProducts(dbpath)

                For Each tAux In t.TraDAO.Trains
                    Me.ListBoxTripsTrains.Items.Add(tAux.TrainID)
                Next

                For Each pAux In p.Products.ProductList
                    Me.ListBoxTripsProduct.Items.Add(pAux.ProductID)
                Next


        End Select


    End Sub

    Private Sub UpdateButtonTrains_Click(sender As Object, e As EventArgs) Handles UpdateButtonTrains.Click
        Try
            Dim t As New Train(ListBoxTrains.SelectedItem.ToString)
            t.TrainType.TrainTypeID = Long.Parse(TextBoxTrainType.Text)
            If t.UpdateTrain() = 1 Then

                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 3
                MessageBox.Show("Train updated correctly", "Train", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = 1
        TabControl1.SelectedIndex = 0

    End Sub

    Private Sub ListViewTrips_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewTrips.SelectedIndexChanged
        If ListViewTrips.SelectedItems IsNot Nothing Then
            DateTimePicker1.Value = Date.Parse(ListViewTrips.Items(ListViewTrips.FocusedItem.Index).SubItems(0).Text)
            TextBoxTripsTrain.Text = ListViewTrips.Items(ListViewTrips.FocusedItem.Index).SubItems(1).Text
            TextBoxTripsProduct.Text = ListViewTrips.Items(ListViewTrips.FocusedItem.Index).SubItems(2).Text
            TextBoxTripsTons.Text = ListViewTrips.Items(ListViewTrips.FocusedItem.Index).SubItems(3).Text
            InsertButtonTrips.Enabled = False
            ListBoxTripsProduct.Enabled = False
            ListBoxTripsTrains.Enabled = False
            DateTimePicker1.Enabled = False
            InsertButtonTrains.Enabled = False
            DeleteButtonTrains.Enabled = True


        End If
    End Sub

    Private Sub UpdateButtonProducts_Click(sender As Object, e As EventArgs) Handles UpdateButtonProducts.Click
        Try
            Dim p As New Product(Long.Parse(ListBoxProducts.SelectedItem.ToString), TextBoxProductDescription.Text)
            If p.UpdateProduct() = 1 Then
                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 1

                MessageBox.Show("Product updated correctly", "Product", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End Try
    End Sub

    Private Sub DeleteButtonProducts_Click(sender As Object, e As EventArgs) Handles DeleteButtonProducts.Click
        Try
            Dim p As New Product(Long.Parse(TextBoxProductID.Text))

            If p.DeleteProduct() = 1 Then
                Me.ClearButtonProducts.PerformClick()
                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 1

                MessageBox.Show("Product has been deleted", "Product", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateButtonPrices_Click(sender As Object, e As EventArgs) Handles UpdateButtonPrices.Click
        Try
            Dim PriceDate As Date = Date.Parse(DateTimePicker2.Value.ToShortDateString)
            Dim p As New Product(Long.Parse(TextBoxPriceProduct.Text))
            Dim pr As New Price(p, PriceDate, Double.Parse(TextBoxPriceEurosTon.Text))
            If pr.UpdatePrice() = 1 Then
                MessageBox.Show("Price updated correctly", "Price", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End Try
    End Sub


    Private Sub DeleteButtonTrips_Click(sender As Object, e As EventArgs) Handles DeleteButtonTrips.Click
        Try
            Dim TripDate As Date = Date.Parse(DateTimePicker1.Value.ToShortDateString)
            Dim p2 As New Product(Long.Parse(Me.TextBoxTripsProduct.Text))
            p2.ReadProduct()
            Dim t2 As New Train(Me.TextBoxTripsTrain.Text)
            t2.ReadTrain()

            Dim trip As New Trip(TripDate, t2, p2)

            If trip.DeleteTrip() = 1 Then
                Me.ClearButtonTrips.PerformClick()
                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 4
                MessageBox.Show("Trip deleted correctly", "Trip", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateButtonTrips_Click(sender As Object, e As EventArgs) Handles UpdateButtonTrips.Click
        Try
            Dim TripDate As Date = Date.Parse(DateTimePicker1.Value.ToShortDateString)
            Dim p2 As New Product(Long.Parse(Me.TextBoxTripsProduct.Text))
            p2.ReadProduct()
            Dim t2 As New Train(Me.TextBoxTripsTrain.Text)
            t2.ReadTrain()
            Dim tons As Long = Long.Parse(Me.TextBoxTripsTons.Text)
            Dim trip As New Trip(TripDate, t2, p2, tons)

            If trip.UpdateTrip() = 1 Then
                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 4
                MessageBox.Show("Trip updated correctly", "Trip", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End Try
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Me.Close()
    End Sub

    Private Sub ListBoxTripsTrains_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxTripsTrains.SelectedIndexChanged
        If ListBoxTripsTrains.SelectedItem IsNot Nothing Then
            TextBoxTripsTrain.Text = Me.ListBoxTripsTrains.SelectedItem.ToString

        End If
    End Sub

    Private Sub ListBoxTripsProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxTripsProduct.SelectedIndexChanged
        If ListBoxTripsProduct.SelectedItem IsNot Nothing Then
            If ListBoxTripsProduct.SelectedItems.Count = 1 Then
                TextBoxTripsProduct.Text = Me.ListBoxTripsProduct.SelectedItem.ToString
            ElseIf ListBoxTripsProduct.SelectedItems.Count > 1 Then
                TextBoxTripsProduct.Text = "Multivalued"
            End If

        End If
    End Sub

    Private Sub ListBoxPricesProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxPricesProduct.SelectedIndexChanged
        If ListBoxPricesProduct.SelectedItem IsNot Nothing Then
            TextBoxPriceProduct.Text = Me.ListBoxPricesProduct.SelectedItem.ToString
            ListBoxPrices.Items.Clear()
            TextBoxPriceEurosTon.Text = ""
            DateTimePicker2.Value = #01/01/1970#

            Dim pp As New Price()
            Dim ppAux As New Price()
            pp.ReadAllPrices(dbpath)

            For Each ppAux In pp.PriDAO.Prices
                If ppAux.Product.ProductID = Long.Parse(ListBoxPricesProduct.SelectedItem.ToString) Then
                    Me.ListBoxPrices.Items.Add(ppAux.PriceDate.ToShortDateString)

                End If
            Next
        End If
    End Sub

    Private Sub DeleteButtonTTypes_Click(sender As Object, e As EventArgs) Handles DeleteButtonTTypes.Click
        Try
            Dim ty As New TrainType(Long.Parse(TextBoxTrainTypeID.Text))

            If ty.DeleteTrainType() = 1 Then
                Me.ClearButtonTTypes.PerformClick()

                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 3

                MessageBox.Show("Train Type has been deleted", "Train Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateButtonTTypes_Click(sender As Object, e As EventArgs) Handles UpdateButtonTTypes.Click
        Try
            Dim t As New TrainType(Long.Parse(TextBoxTrainTypeID.Text), TextBoxTrainTypeDescription.Text, Long.Parse(TextBoxTrainTypeMaxCapacity.Text))
            If t.UpdateTrainType() = 1 Then

                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 3
                MessageBox.Show("Train Type updated correctly", "Train Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Me.Close()
    End Sub

    Private Sub DeleteButtonPrices_Click(sender As Object, e As EventArgs) Handles DeleteButtonPrices.Click
        Try
            Dim p As New Product(Long.Parse(TextBoxPriceProduct.Text))
            Dim pr As New Price(p, DateTimePicker2.Value)

            If pr.DeletePrice() = 1 Then
                Me.ClearButtonPrices.PerformClick()
                TabControl1.SelectedIndex = 0
                TabControl1.SelectedIndex = 2

                MessageBox.Show("Price has been deleted", "Price", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, ex.Source.ToString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        FormRankingTypeTrains.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormRankingProducts.Show()

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        FormTripsAndProducts.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        FormInformation.Show()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Me.Close()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Me.Close()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Me.Close()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Me.Close()
    End Sub
End Class