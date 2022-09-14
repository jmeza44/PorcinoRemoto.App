using System.Collections.Generic;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PorcinoRemoto.App.Frontend.Pages;

public class RegistroVetModel : PageModel
{
    private readonly ILogger<RegistroVetModel> _logger;
    [BindProperty]
    public Veterinario veterinarioPost { get; set; }
    public IRepositorioVeterinario _repoVeterinario;

    public RegistroVetModel(ILogger<RegistroVetModel> logger)
    {
        _logger = logger;
        _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
    }

    public void OnGet()
    {
    }

    public void Onpost()
    {
        verificarSegundosNomApe();
        _repoVeterinario.AddVeterinario(veterinarioPost);
    }
    public void verificarSegundosNomApe()
    {
        if (veterinarioPost.Persona.SegundoNombre == null)
        {
            veterinarioPost.Persona.SegundoNombre = "";
        }
        if (veterinarioPost.Persona.SegundoApellido == null)
        {
            veterinarioPost.Persona.SegundoApellido = "";
        }
    }
}
