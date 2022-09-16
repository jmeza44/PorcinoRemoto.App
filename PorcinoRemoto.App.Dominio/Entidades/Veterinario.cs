using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PorcinoRemoto.App.Dominio
{
    public class Veterinario
    {
        [Key]
        public string PersonaID { get; set; }
        public string TarjetaProfesional { get; set; }
        [ForeignKey("PersonaID")]
        public virtual Persona Persona { get; set; }
        public virtual List<Visita> Visitas { get; set; }
    }
}