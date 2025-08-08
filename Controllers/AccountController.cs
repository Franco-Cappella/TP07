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

    public IActionResult Index(string username, string password)
    {
        Usuario user = BD.Login(username, password);
        if (user == null){ViewBag.msjError = "El usuario no esta guardado en nuestra base de datos. Por favor Registrese.";}
        else{HttpContext.Session.SetString("id", user.id.ToString());}
        return View();
    }

    public IActionResult Registro(string username, string password, string nombre, string apellido, string foto)
    {
        bool siNo = false;
        bool esta = BD.Esta(username);    
        if (!esta){siNo = BD.Registrarse(username, password, nombre, apellido, foto);}
        else ViewBag.MsjError = "Ya existe el username";
        if (!siNo){ViewBag.MsjError = "No se pudo registrar el nuevo usuario, intentelo nuevamente";}
        return View();
    }
}