using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioHistoriaClinica
    {
        IEnumerable<HistoriaClinica> GetAllHistoriasClinicas();
        HistoriaClinica GetHistoriaClinica(int idHistoriaClinica);
        HistoriaClinica AddHistoriaClinica(HistoriaClinica historiaClinica);
        HistoriaClinica UpdateHistoriaClinica(HistoriaClinica historiaClinica);
        void DeleteHistoriaClinica(int idHistoriaClinica);
    }
}