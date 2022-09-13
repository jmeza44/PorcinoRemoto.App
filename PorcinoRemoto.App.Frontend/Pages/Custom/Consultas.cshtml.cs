using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PorcinoRemoto.App.Frontend.Pages;

public class Porcino
{
    public int PorcinoID { get; set; }
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public string Raza { get; set; }
    public string Color { get; set; }
    public string Propietario { get; set; }
    public string Historia { get; set; }
}

public class ConsultasModel : PageModel
{
    private readonly ILogger<ConsultasModel> _logger;
    public List<Porcino> porcinos = new List<Porcino>()
    {
        new Porcino(){ PorcinoID = 1, Nombre="Bill", Especie="Barbatus ", Raza="Razorback", Color="Blanco y Negro", Propietario="Juan Carlos", Historia="NEALX3EPYB"},
        new Porcino(){ PorcinoID = 2, Nombre="Otto", Especie="Cebifrons ", Raza="Yorkshire", Color="Marrón", Propietario="Jose Luis", Historia="928B7I9HPY"},
        new Porcino(){ PorcinoID = 3, Nombre="Ram", Especie="Bucculentus", Raza="Landrace", Color="Negro", Propietario="Fernando", Historia="QQBKNAWJP3"},
        new Porcino(){ PorcinoID = 4, Nombre="Dooppy", Especie="Celebensis", Raza="Affinis", Color="Marrón", Propietario="Duilio Paredes", Historia="NUYUVL5O8Z"},
        new Porcino(){ PorcinoID = 5, Nombre="Cloe", Especie="Heureni", Raza="Majori ", Color="Blanco y Negro", Propietario="Ray Barajas", Historia="6N8ZSE2CLE"},
        new Porcino(){ PorcinoID = 6, Nombre="Mockpig", Especie="Philippensis", Raza="Landrace", Color="Marrón", Propietario="Bernabela Arana", Historia="O2X115E2UJ"},
        new Porcino(){ PorcinoID = 7, Nombre="Ramsie", Especie="Salvanius", Raza="Meridionalis ", Color="Blanco y Negro", Propietario="Melquisedec Leal", Historia="IDVHB9MOEQ"},
        new Porcino(){ PorcinoID = 8, Nombre="Buttra", Especie="Scrofa", Raza="Nicobaricus ", Color="Marrón", Propietario="Isachar Saldivar", Historia="LBKDV1W7J9"},
        new Porcino(){ PorcinoID = 9, Nombre="Clonoi", Especie="Timorensis", Raza="Papuensis ", Color="Marrón", Propietario="Leuter Nieves", Historia="PZIVEY3MTR"},
        new Porcino(){ PorcinoID = 10, Nombre="Prime", Especie="Verrucosus ", Raza="Sardous ", Color="Negro", Propietario="Paris Ozuna", Historia="134QGPY9UH"}
    };

    public ConsultasModel(ILogger<ConsultasModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet(string nombre)
    {
        if (nombre == null) {
            return Page();
        } else {
            porcinos = BuscarPorcino(nombre);
            return Page();
        }
    }

    public List<Porcino> BuscarPorcino(string nombre)
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