using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;

namespace PorcinoRemoto.App.Frontend.Pages;

public class DetallePorcinoModel : PageModel
{
    private readonly ILogger<DetallePorcinoModel> _logger;
    [BindProperty]
    public Porcino porcino { get; set; }
    public readonly IRepositorioPorcino _repoPorcino;

    public DetallePorcinoModel(ILogger<DetallePorcinoModel> logger)
    {
        _logger = logger;
        _repoPorcino = new RepositorioPorcino(new Persistencia.AppContext());
    }

    public IActionResult OnGet(int idPorcino)
    {
        if (idPorcino == null || idPorcino == 0)
        {
            return RedirectToPage("/Error");
        }
        porcino = _repoPorcino.GetPorcino(idPorcino);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (porcino != null)
        {
            _repoPorcino.DeletePorcino(porcino.PorcinoID);
            return RedirectToPage("/Custom/Consultas");
        }
        return Page();
    }
}