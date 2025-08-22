using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace TP07.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AccountController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        int idUsuario = null;
        if(i > 0) idUsuario = int.Parse(HttpContext.Session.GetString("id"));
        
        if (idUsuario != null)
        {
            return RedirectToAction("CargarTareas");
        }
        else
        {
            int i = 0;
            i++;
            Usuario user = BD.Login(username, password);

            if (user == null)
            {
                ViewBag.msjError = "El usuario no esta guardado en nuestra base de datos. Por favor Registrese.";
                return View("Login");
            }
            else
            {
                HttpContext.Session.SetString("id", user.id.ToString());
                return RedirectToAction("CargarTareas");
            }
        }

    }

    public IActionResult Login1()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult Registro(string username, string password, string nombre, string apellido, string foto)
    {
        int idUsuario = int.Parse(HttpContext.Session.GetString("id"));
        if (idUsuario != null)
        {
            return RedirectToAction("CargarTareas");
        }
        else
        {
            
        if (!BD.Esta(username))
        {
            BD.Registrarse(username, password, nombre, apellido, foto);
        }
        else
        {
            ViewBag.MsjError = "Ya existe el username";
        }
        return View("Login");
        }
    }
    public IActionResult Registro1()
    {
        return View("Registro");
    }
}