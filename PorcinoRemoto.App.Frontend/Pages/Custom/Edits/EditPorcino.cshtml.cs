using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;

namespace PorcinoRemoto.App.Frontend.Pages;

public class EditPorcinoModel : PageModel
{
    private readonly ILogger<EditPorcinoModel> _logger;
    [BindProperty]
    public Porcino porcinoPost { get; set; }
    public readonly IRepositorioPorcino _repoPorcino;

    public EditPorcinoModel(ILogger<EditPorcinoModel> logger)
    {
        _logger = logger;
        _repoPorcino = new RepositorioPorcino(new Persistencia.AppContext());
    }

    public IActionResult OnGet(int idPorcino)
    {
        if (idPorcino == 0)
        {
            return RedirectToPage("/Error");
        }
        porcinoPost = _repoPorcino.GetPorcino(idPorcino);
        return Page();
    }

    public IActionResult Onpost()
    {
        porcinoPost = _repoPorcino.UpdatePorcino(porcinoPost);
        if (porcinoPost != null)
        {
            return RedirectToPage("/Custom/Consultas");
        }
        return Page();
    }
}