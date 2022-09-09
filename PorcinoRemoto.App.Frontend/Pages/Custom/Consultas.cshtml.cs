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
    public List<Porcino> porcinos = new List<Porcino>() {
                new Porcino(){ PorcinoID = 1, Nombre="Bill", Especie="", Raza="Razorback", Color="Blanco y Negro", Propietario="Juan Carlos", Historia="A3654G2356"},
                new Porcino(){ PorcinoID = 2, Nombre="Otto", Especie="", Raza="Yorkshire", Color="Marron", Propietario="Jose Luis", Historia="A3654G2356"},
                new Porcino(){ PorcinoID = 3, Nombre="Ram", Especie="", Raza="Landrace", Color="Negro", Propietario="Fernando", Historia="A3654G2356"}};

    public ConsultasModel(ILogger<ConsultasModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}



                