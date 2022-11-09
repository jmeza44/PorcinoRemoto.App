using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;

namespace PorcinoRemoto.App.Frontend.Pages;

public class DetalleHistoriaClinicaModel : PageModel
{
    private readonly ILogger<DetalleHistoriaClinicaModel> _logger;
    public PorcinoRemoto.App.Dominio.HistoriaClinica historia;
    public readonly IRepositorioHistoriaClinica _repoHistoria;

    public DetalleHistoriaClinicaModel(ILogger<DetalleHistoriaClinicaModel> logger)
    {
        _logger = logger;
        _repoHistoria = new RepositorioHistoriaClinica(new Persistencia.AppContext());
    }
    public IActionResult OnGet(int idHistoria)
    {
        if (idHistoria == 0) {
            return RedirectToPage("/Error");
        }
        historia = _repoHistoria.GetHistoriaClinica(idHistoria);
        return Page();
    }
}