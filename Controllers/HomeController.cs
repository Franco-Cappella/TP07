using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace TP07.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Login1", "Account");
    }

    public IActionResult CargarTareas(){
        int idUsuario = int.Parse(HttpContext.Session.GetString("id"));
        ViewBag.Tareas = BD.TraerTareas(idUsuario);
        return View("Tareas");
    }
    public IActionResult CrearTarea(){
        return View("CrearTarea");
    }

    [HttpPost]
    public IActionResult CrearTareaGuardar(string titulo, string descripcion, DateTime fecha){
        int idUsuario = int.Parse(HttpContext.Session.GetString("id"));
        Tarea tarea = new Tarea(idUsuario, titulo, descripcion, fecha);
        BD.CrearTarea(tarea);
        return View("Tareas");
    }
    public IActionResult EliminarTarea(Tarea tarea){
        int idUsuario = int.Parse(HttpContext.Session.GetString("id"));
        BD.EliminarTarea(tarea.id);
        tarea.Papelera.Remove(tarea);
        return View("Tareas");
    }
    public IActionResult FinalizarTarea(Tarea tarea){
        int idUsuario = int.Parse(HttpContext.Session.GetString("id"));
        tarea.finalizada = true;
        BD.ActualizarTarea(tarea.id);
        tarea.Papelera.Add(tarea); 
        return View("Tareas");
    }
    public IActionResult EditarTarea(int idTarea){
        ViewBag.idTarea = idTarea;
        return View("EditarTarea");
    }

    [HttpPost]
    public IActionResult EditarTareaGuardar(string titulo, string descripcion, DateTime fecha){
        int idUsuario = int.Parse(HttpContext.Session.GetString("id"));
        BD.EditarTarea(idUsuario, titulo, descripcion, fecha);
        return View("Tareas");
    }
    

}
