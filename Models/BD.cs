using Microsoft.Data.SqlClient;
using Dapper;
using TP07.Models;
using System.Collections.Generic;

public static class BD
{
    private static string _connectionString = @"Server=localhost; 
    DataBase = TP06-prog; Integrated Security=True; TrustServerCertificate=True;";

    public static Usuario Login(string Nombre, string Contraseña)
    {
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrantes WHERE username = @Nombre AND password = @Contraseña";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { username = Nombre, password = Contraseña });
        }
        return usuario;
    }

    public static bool Esta(string Nombre)
    {
        bool esta = false;
        Usuario usuario;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrantes WHERE username = @Nombre";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { username = Nombre });
        }
        if (usuario != null) { esta = true; }
        return esta;
    }

    public static bool Registrarse(string pUsername, string pPassword, string pNombre, string pApellido, string pFoto)
    {
        bool siNo = false;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Usuarioss (username, password, nombre, apellido, foto) VALUES (@Username, @Password, @Nombre, @Apellido, @Foto)";
            connection.Execute(query, new { Username = pUsername, Password = pPassword, Nombre = pNombre, Apellido = pApellido, Foto = pFoto });
        }
        siNo = Esta(pUsername);
        return siNo;
    }

    public static List<Tarea> TraerTareas(int IDU)
    {
        List<Tarea> Tareas = new List<Tarea>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE idU = @id";
            Tareas = connection.Query<Tarea>(query, new { id = IDU }).ToList();
        }
        return Tareas;
    }

    public static void CrearTarea(Tarea tarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Tareas (idU, titulo, fecha, descripcion) VALUES (@IDU, @TITULO, @FECHA, @DESCRIPCION)";
            connection.Execute(query, new { IDU = tarea.id, TITULO = tarea.titulo, FECHA = tarea.fecha, DESCRIPCION = tarea.descripcion});
        }
    }
    public static void EliminarTarea(int idTarea){
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE * FROM Tareas WHERE id = @ID";
            connection.Execute(query, new { ID = idTarea});
        }
    }

}