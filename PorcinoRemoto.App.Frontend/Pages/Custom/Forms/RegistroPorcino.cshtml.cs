using System.Collections.Generic;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace PorcinoRemoto.App.Frontend.Pages;

public class RegistroPorModel : PageModel
{
    private readonly ILogger<RegistroPorModel> _logger;
    [BindProperty]
    public Porcino porcinoPost { get; set; }
    [BindProperty]
    public Propietario propietarioPost { get; set; }
    public IRepositorioPorcino _repoPorcino;

    public RegistroPorModel(ILogger<RegistroPorModel> logger)
    {
        _logger = logger;
        _repoPorcino = new RepositorioPorcino(new Persistencia.AppContext());
    }

    public void OnGet()
    {

    }

    public void Onpost()
    {
        verificarSegundosNomApe();
        porcinoPost.Propietario = propietarioPost;
        porcinoPost.HistoriaClinica = new HistoriaClinica() { FechaGeneracion = DateTime.Now };
        _repoPorcino.AddPorcino(porcinoPost);
    }

    public void verificarSegundosNomApe()
    {
        if (propietarioPost.Persona.SegundoNombre == null)
        {
            propietarioPost.Persona.SegundoNombre = "";
        }
        if (propietarioPost.Persona.SegundoApellido == null)
        {
            propietarioPost.Persona.SegundoApellido = "";
        }
    }
}
