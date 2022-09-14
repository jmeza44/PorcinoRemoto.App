using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;
        public RepositorioVisita(AppContext appContext)
        {
            _appContext = appContext;
        }

        IEnumerable<Visita> IRepositorioVisita.GetAllVisitas()
        {
            return _appContext.Visitas;
        }

        Visita IRepositorioVisita.GetVisita(int idVisita)
        {
            return _appContext.Visitas.FirstOrDefault(p => p.VisitaID == idVisita);
        }

        Visita IRepositorioVisita.AddVisita(Visita visita)
        {
            var visitaAdicionada = _appContext.Visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaAdicionada.Entity;
        }

        Visita IRepositorioVisita.UpdateVisita(Visita visita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(p => p.VisitaID == visita.VisitaID);
            if (visitaEncontrada != null)
            {
                visitaEncontrada.FechaVisita = visita.FechaVisita;
                visitaEncontrada.Temperatura = visita.Temperatura;
                visitaEncontrada.Peso = visita.Peso;
                visitaEncontrada.EstadoAnimo = visita.EstadoAnimo;
                visitaEncontrada.FrecuenciaRespiratoria = visita.FrecuenciaRespiratoria;
                visitaEncontrada.FrecuenciaCardiaca = visita.FrecuenciaCardiaca;
                visitaEncontrada.MedicamentosFormulados = visita.MedicamentosFormulados;
                visitaEncontrada.Porcino = visita.Porcino;
                visitaEncontrada.Veterinario = visita.Veterinario;
                visitaEncontrada.HistoriaClinica = visita.HistoriaClinica;

                _appContext.SaveChanges();
            }
            return visitaEncontrada;
        }

        void IRepositorioVisita.DeleteVisita(int idVisita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(p => p.VisitaID == idVisita);
            if (visitaEncontrada == null)
                return;
            _appContext.Visitas.Remove(visitaEncontrada);
            _appContext.SaveChanges();

        }

    }
}