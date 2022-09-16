using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorcinoRemoto.App.Dominio
{
    public class Porcino
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PorcinoID { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string? PropietarioID { get; set; }
        public int HistoriaID { get; set; }
        [ForeignKey("PropietarioID")]
        public virtual Propietario? Propietario { get; set; }
        [ForeignKey("HistoriaID")]
        public virtual HistoriaClinica HistoriaClinica { get; set; }
        public virtual List<Visita> Visitas { get; set; }
    }
}