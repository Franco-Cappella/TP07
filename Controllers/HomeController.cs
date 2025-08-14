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
        Usuario Usu = new Usuario();
        ViewBag.Tareas = BD.TraerTarea(Usu.id);
        return View("Tareas");
    }

    public IActionResult CrearTarea(){
        
    }

}
