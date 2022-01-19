using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CadastroWeb.Models;

namespace CadastroWeb.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Responder(int? id){
        var user = new Usuario();
        if(id.HasValue){
            if(Usuario.Listagem.Any(u => u.Id==id)){
                user = Usuario.Listagem.Single(u => u.Id==id);
            }
        } 
        return View(user);
    }
    [HttpPost]
    public IActionResult Responder(Usuario usuario){

        Usuario.Salvar(usuario);
        return RedirectToAction("Resultado");
    }
    public IActionResult Resultado(Usuario usuario){
        
        return View(Usuario.Listagem);
    }
    [HttpGet]
    public IActionResult Deletar(int id){
        Usuario.Excluir(id);
        return RedirectToAction("Resultado");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
