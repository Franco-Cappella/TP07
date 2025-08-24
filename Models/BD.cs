using Microsoft.Data.SqlClient;
using Dapper;
using TP07.Models;
using System.Collections.Generic;

public static class BD
{
    private static string _connectionString = @"Server=localhost; 
    DataBase = TP07; Integrated Security=True; TrustServerCertificate=True;";

    public static Usuario Login(string Nombre, string Contraseña)
    {
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarioss WHERE username = @Nombre AND password = @Contraseña";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { username = Nombre, password = Contraseña });
        }
        return usuario;
    }

    public static bool Esta(string Nom)
    {
        bool esta = false;
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarioss WHERE username = @Nombre";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { @Nombre = Nom });
        }
        if (usuario != null) { esta = true; }
        return esta;
    }

    public static bool Registrarse(string pUsername, string pPassword, string pNombre, string pApellido, string pFoto)
    {

        bool registro = false;
        if (!Esta(pUsername))
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Usuarioss (username, password, nombre, apellido, foto) VALUES (@Username, @Password, @Nombre, @Apellido, @Foto)";
                connection.Execute(query, new { Username = pUsername, Password = pPassword, Nombre = pNombre, Apellido = pApellido, Foto = pFoto });
            }
            registro = true;
        }
        return registro;
    }

    public static List<Tarea> TraerTareas(int IDU)
    {
        List<Tarea> Tareas = new List<Tarea>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE idu = @id";
            Tareas = connection.Query<Tarea>(query, new { id = IDU }).ToList();
        }
        return Tareas;
    }

    public static void CrearTarea(Tarea tarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Tareas (idu, titulo, fecha, descripcion, finalizada) VALUES (@IDU, @TITULO, @FECHA, @DESCRIPCION, @FINALIZADA)";
            connection.Execute(query, new { IDU = tarea.idU, TITULO = tarea.titulo, FECHA = tarea.fecha, DESCRIPCION = tarea.descripcion, FINALIZADA = 0 });
        }
    }
    public static void EliminarTarea(int idTarea)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE FROM Tareas WHERE id = @ID";
            connection.Execute(query, new { ID = idTarea });
        }
    }
    public static Tarea TraerTarea(int idTarea)
    {

        Tarea Tarea = new Tarea();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE id = @idT AND finalizada = 0";
            Tarea = connection.QueryFirstOrDefault<Tarea>(query, new { idT = idTarea });
        }
        return Tarea;


    }
    public static void ActualizarTarea(int idTarea)
    {

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET finalizada = 1 WHERE id = @ID";
            connection.Execute(query, new { ID = idTarea });
        }
    }


    public static void ActualizarLogin(int IDusu)
    {

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Usuarioss SET ultimologin = GETDATE() WHERE id = @id";
            connection.Execute(query, new { id = IDusu });
        }
    }
    public static void EditarTarea(int idTarea, string ptitulo, string pdescripcion, DateTime pfecha)
    {

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET titulo = @titulo, descripcion = @descripcion, fecha = @fecha WHERE id = @id";
            connection.Execute(query, new { id = idTarea, titulo = ptitulo, fecha = pfecha, descripcion = pdescripcion });
        }
    }
}
