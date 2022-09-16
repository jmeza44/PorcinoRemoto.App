using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PorcinoRemoto.App.Dominio
{
    public class Propietario
    {
        [Key]
        public string PersonaID {get;set;}
        public string Email { get; set; }
        [ForeignKey("PersonaID")]
        public virtual Persona Persona { get; set; }
        public virtual List<Porcino> Porcinos { get; set; }
    }
}