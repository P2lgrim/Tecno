Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Registros
    Dim con As New SqlConnection(My.Settings.Login)
    Dim mensaje, sentencia As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()
    End Sub

    Sub EjecutarSql(ByVal sql As String, ByVal msg As String)
        Try
            Dim cmd As New SqlCommand(sql, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox(msg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sentencia = "Insert into registros values('" + txtid.Text + "','" + txtnombre.Text + "','" + txtcorreo.Text + "','" + txtpais.Text + "','" + txtocupacion.Text + "')"
        mensaje = "Datos insertados correctamente"
        EjecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("Select * From registros", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.GunaDataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim da As New SqlDataAdapter("Select * From registros Where id = '" + txtid.Text + "'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        Me.GunaDataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Application.Exit()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        sentencia = "Delete registros Where id = '" + txtid.Text + "'"
        mensaje = "Datos eliminados correctamente"
        EjecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("Select * From registros", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.GunaDataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        sentencia = "update registros set Nombre = '" + txtnombre.Text + "', Correo = '" + txtcorreo.Text + "', Pais = '" + txtpais.Text + "', Ocupacion = '" + txtocupacion.Text + "' where id = '" + txtid.Text + "'"
        mensaje = "Datos actualizados Correctamente"
        EjecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("select * from registros", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.GunaDataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick

    End Sub
End Class