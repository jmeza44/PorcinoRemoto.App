using PorcinoRemoto.App.Dominio;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioHistoriaClinica
    {
        List<HistoriaClinica> GetAllHistoriasClinicas();
        HistoriaClinica GetHistoriaClinica(int idHistoriaClinica);
        HistoriaClinica AddHistoriaClinica(HistoriaClinica historiaClinica);
        HistoriaClinica UpdateHistoriaClinica(HistoriaClinica historiaClinica);
        void DeleteHistoriaClinica(int idHistoriaClinica);
    }
}