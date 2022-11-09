using System.Collections.Generic;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace PorcinoRemoto.App.Frontend.Pages;

public class RegistroVisitaModel : PageModel
{
    private readonly ILogger<RegistroVisitaModel> _logger;
    [BindProperty]
    public Visita visita { get; set; }
    public List<Veterinario> veterinarios { get; set; }
    public readonly IRepositorioVisita _repoVisita;
    public readonly IRepositorioVeterinario _repoVeterinario;

    public RegistroVisitaModel(ILogger<RegistroVisitaModel> logger)
    {
        _logger = logger;
        _repoVisita = new RepositorioVisita(new Persistencia.AppContext());
        _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
    }

    public IActionResult OnGet(int idPorcino)
    {
        if (idPorcino == null || idPorcino == 0)
        {
            return RedirectToPage("/Error");
        }
        veterinarios = _repoVeterinario.GetAllVeterinario();
        visita = new Visita();
        visita.PorcinoID = idPorcino;
        return Page();
    }

    public IActionResult OnPost()
    {
        visita = _repoVisita.AddVisita(visita);
        if (visita != null)
        {
            return RedirectToPage("/Custom/Consultas");
        }
        return Page();
    }
}