Public Class ConnectForm
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        Try

            Dim t As New Train
            t.ReadAllTrains(System.IO.Path.GetFullPath(OpenFileDialog1.FileName))
            If OpenFileDialog1.FileName.EndsWith(".accdb") Then
                MainForm.Show()
            Else
                MessageBox.Show("You have selected a wrong database", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub PathButton_Click(sender As Object, e As EventArgs) Handles PathButton.Click
        Try


            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                LabelPath.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
                ConnectButton.Enabled = True

            Else
                HelpLabel.Text = "Error, select a valid database"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub


End Class