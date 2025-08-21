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

}
