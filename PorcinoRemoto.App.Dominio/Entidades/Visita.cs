namespace PorcinoRemoto.App.Dominio
{
    public class Visita
    {
        public DateTime fechaVisita { get; set; }
        public double temperatura { get; set; }
        public double peso { get; set; }
        public string estadoAnimo { get; set; }
        public double frecuenciaRespiratoria { get; set; }
        public double frecuenciaCardiaca { get; set; }
        public List<String> medicamentosFormulados { get; set; }
        public Veterinario veterinarioEncargado { get; set; }
        public Porcino porcinoVisitado { get; set; }
        public HistoriaClinica historia { get; set; }

        public Visita(DateTime fechaVisita, double temperatura, double peso, string estadoAnimo, double frecuenciaRespiratoria, double frecuenciaCardiaca, List<String> medicamentosFormulados, Veterinario veterinarioEncargado, Porcino porcinoVisitado, HistoriaClinica historia)
        {
            this.fechaVisita = fechaVisita;
            this.temperatura = temperatura;
            this.peso = peso;
            this.estadoAnimo = estadoAnimo;
            this.frecuenciaRespiratoria = frecuenciaRespiratoria;
            this.frecuenciaCardiaca = frecuenciaCardiaca;
            this.medicamentosFormulados = medicamentosFormulados;
            this.veterinarioEncargado = veterinarioEncargado;
            this.porcinoVisitado = porcinoVisitado;
            this.historia = historia;
        }
    }
}