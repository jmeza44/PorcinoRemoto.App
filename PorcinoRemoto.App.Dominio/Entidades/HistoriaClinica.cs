namespace PorcinoRemoto.App.Dominio
{
    public class HistoriaClinica
    {
        public DateTime fechaGeneracion { get; set; }

        public HistoriaClinica(DateTime fechaGeneracion)
        {
            this.fechaGeneracion = fechaGeneracion;
        }
    }
}