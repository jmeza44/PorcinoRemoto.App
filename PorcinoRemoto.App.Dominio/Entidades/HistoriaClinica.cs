using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorcinoRemoto.App.Dominio
{
    public class HistoriaClinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoriaID { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public virtual List<Visita> Visitas { get; set; }
    }
}