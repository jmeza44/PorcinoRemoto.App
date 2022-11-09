using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;

namespace PorcinoRemoto.App.Frontend.Pages;

public class DetallePropietarioModel : PageModel
{
    private readonly ILogger<DetallePropietarioModel> _logger;
    [BindProperty]
    public Propietario propietario { get; set; }
    public readonly IRepositorioPropietario _repoPropietario;

    public DetallePropietarioModel(ILogger<DetallePropietarioModel> logger)
    {
        _logger = logger;
        _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());
    }
    public IActionResult OnGet(string idPropietario)
    {
        if (idPropietario == null)
        {
            return RedirectToPage("/Error");
        }
        propietario = _repoPropietario.GetPropietario(idPropietario);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (propietario != null)
        {
            _repoPropietario.DeletePropietario(propietario.PersonaID);
            return RedirectToPage("/Custom/Consultas");
        }
        return Page();
    }
}