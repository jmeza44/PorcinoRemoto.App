using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PorcinoRemoto.App.Dominio
{
    public class Persona
    {
        [Key]
        public string PersonaID { get; set; }
        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public int DireccionID { get; set; }
        [ForeignKey("DireccionID")]
        public virtual Direccion Direccion { get; set; }
    }
}