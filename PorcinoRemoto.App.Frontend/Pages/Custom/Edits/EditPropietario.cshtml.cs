using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;

namespace PorcinoRemoto.App.Frontend.Pages;

public class EditPropietarioModel : PageModel
{
    private readonly ILogger<EditPropietarioModel> _logger;
    [BindProperty]
    public Propietario propietarioPost { get; set; }
    public readonly IRepositorioPropietario _repoPropietario;

    public EditPropietarioModel(ILogger<EditPropietarioModel> logger)
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
        propietarioPost = _repoPropietario.GetPropietario(idPropietario);
        return Page();
    }
    public IActionResult OnPost()
    {
        propietarioPost = _repoPropietario.UpdatePropietario(propietarioPost);
        return Page();
    }
}