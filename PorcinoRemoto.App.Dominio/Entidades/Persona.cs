using System.ComponentModel.DataAnnotations;
namespace PorcinoRemoto.App.Dominio
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Direccion Direccion { get; set; }
    }
}