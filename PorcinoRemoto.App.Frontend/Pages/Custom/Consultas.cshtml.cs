using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;

namespace PorcinoRemoto.App.Frontend.Pages;

public class ConsultasModel : PageModel
{
    private readonly ILogger<ConsultasModel> _logger;
    public List<Porcino> porcinos;
    public List<Veterinario> veterinarios;
    public readonly IRepositorioPorcino _repoPorcino;
    public readonly IRepositorioVeterinario _repoVeterinario;

    public ConsultasModel(ILogger<ConsultasModel> logger)
    {
        _logger = logger;
        porcinos = new List<Porcino>();
        _repoPorcino = new RepositorioPorcino(new Persistencia.AppContext());
        _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
    }

    public IActionResult OnGet(string nombre)
    {
        porcinos = _repoPorcino.GetAllPorcinos();
        veterinarios = _repoVeterinario.GetAllVeterinario();
        if (nombre != null)
        {
            porcinos = FiltrarPorcinos(nombre);
        }
        return Page();
    }

    public List<Porcino> FiltrarPorcinos(string nombre)
    {
        List<Porcino> filtrado = new List<Porcino>();
        foreach (var porcino in porcinos)
        {
            if (porcino.Nombre.ToLower().StartsWith(nombre.ToLower()))
            {
                filtrado.Add(porcino);
            }
        }
        return filtrado;
    }
}