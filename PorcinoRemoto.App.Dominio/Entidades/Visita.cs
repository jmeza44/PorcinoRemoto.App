using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorcinoRemoto.App.Dominio
{
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitaID { get; set; }
        public DateTime FechaVisita { get; set; }
        public double Temperatura { get; set; }
        public double Peso { get; set; }
        public string EstadoAnimo { get; set; }
        public double FrecuenciaRespiratoria { get; set; }
        public double FrecuenciaCardiaca { get; set; }
        public string MedicamentosFormulados { get; set; }
        public Porcino Porcino { get; set; }
        public Veterinario Veterinario { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
    }
}