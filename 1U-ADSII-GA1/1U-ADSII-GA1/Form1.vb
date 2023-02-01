Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Form1
    Dim constring As String = "Data Source=PC39LAB5;Initial Catalog=ADSIIG1;Integrated Security=True"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim adapter As New SqlDataAdapter
    Public mensaje, sentencia As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using con As New SqlConnection(constring)
                con.Open()
                Dim sql As New String("Select * From Login Where Usuario = @Usuario And contraseña = @contraseña")
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("Usuario", txtusuario.Text)
                cmd.Parameters.AddWithValue("contraseña", txtcontraseña.Text)
                adapter = New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adapter.Fill(ds)
                If (ds.Tables(0).Rows.Count > 0) Then
                    Dim Form2 As New Registros
                    Form2.Show()

                Else

                    MessageBox.Show("Username or password Invalid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                con.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
