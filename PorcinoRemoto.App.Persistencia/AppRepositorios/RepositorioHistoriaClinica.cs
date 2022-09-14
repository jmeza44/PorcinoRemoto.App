using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioHistoriaClinica : IRepositorioHistoriaClinica
    {
        private readonly AppContext _appContext;
        public RepositorioHistoriaClinica(AppContext appContext)
        {
            _appContext = appContext;
        }

        IEnumerable<HistoriaClinica> IRepositorioHistoriaClinica.GetAllHistoriasClinicas()
        {
            return _appContext.HistoriasClinicas;
        }

        HistoriaClinica IRepositorioHistoriaClinica.GetHistoriaClinica(int idHistoriaClinica)
        {
            return _appContext.HistoriasClinicas.FirstOrDefault(p => p.HistoriaID == idHistoriaClinica);
        }

        HistoriaClinica IRepositorioHistoriaClinica.AddHistoriaClinica(HistoriaClinica historiaClinica)
        {
            var historiaClinicaAdicionada = _appContext.HistoriasClinicas.Add(historiaClinica);
            _appContext.SaveChanges();
            return historiaClinicaAdicionada.Entity;
        }

        HistoriaClinica IRepositorioHistoriaClinica.UpdateHistoriaClinica(HistoriaClinica historiaClinica)
        {
            var historiaClinicaEncontrada = _appContext.HistoriasClinicas.FirstOrDefault(p => p.HistoriaID == historiaClinica.HistoriaID);
            if (historiaClinicaEncontrada != null)
            {
                historiaClinicaEncontrada.FechaGeneracion = historiaClinica.FechaGeneracion;

                _appContext.SaveChanges();
            }
            return historiaClinicaEncontrada;
        }

        void IRepositorioHistoriaClinica.DeleteHistoriaClinica(int idHistoriaClinica)
        {
            var historiaClinicaEncontrada = _appContext.HistoriasClinicas.FirstOrDefault(p => p.HistoriaID == idHistoriaClinica);
            if (historiaClinicaEncontrada == null)
                return;
            _appContext.HistoriasClinicas.Remove(historiaClinicaEncontrada);
            _appContext.SaveChanges();

        }

    }
}