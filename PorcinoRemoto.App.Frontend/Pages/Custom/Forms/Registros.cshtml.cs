using System.Collections.Generic;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace PorcinoRemoto.App.Frontend.Pages;

public class RegistrosModel : PageModel
{
    private readonly ILogger<RegistrosModel> _logger;
    protected IRepositorioPersona _repoPersona;

    public RegistrosModel(ILogger<RegistrosModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
    }

    public IActionResult Onpost()
    {
        _repoPersona.AddPersona();
        return Page();
    }
}
