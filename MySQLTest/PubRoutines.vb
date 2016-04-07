Imports MySql.Data.MySqlClient
Module PubRoutines
    Public Sub LoadLocations()
        Dim myConn As New MySqlConnection
        Dim myCmd As New MySqlCommand
        Dim myRdr As MySqlDataReader

        myConn.ConnectionString = ConnString

        myConn.Open()

        myCmd.Connection = myConn
        myCmd.CommandTimeout = 300
        myCmd.CommandType = CommandType.Text
        myCmd.CommandText = "SELECT * FROM Locations"
        Try
            myRdr = myCmd.ExecuteReader
            Do While myRdr.Read
                Form1.cmbLocations.Items.Add(myRdr.Item("Location").ToString)
            Loop
            myRdr.Close()
            myConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
