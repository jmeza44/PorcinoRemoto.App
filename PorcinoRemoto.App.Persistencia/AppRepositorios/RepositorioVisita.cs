using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;
        public RepositorioVisita(AppContext appContext)
        {
            _appContext = appContext;
        }

        List<Visita> IRepositorioVisita.GetAllVisitas()
        {
            return _appContext.Visitas
            .Include(p => p.Porcino.Propietario.Persona.Direccion)
            .Include(p => p.Porcino.HistoriaClinica)
            .Include(p => p.Veterinario.Persona.Direccion)
            .ToList();
        }

        Visita IRepositorioVisita.GetVisita(int idVisita)
        {
            return _appContext.Visitas
            .Include(p => p.Porcino.Propietario.Persona.Direccion)
            .Include(p => p.Porcino.HistoriaClinica)
            .Include(p => p.Veterinario.Persona.Direccion)
            .FirstOrDefault(p => p.VisitaID == idVisita);
        }

        Visita IRepositorioVisita.AddVisita(Visita visita)
        {
            Veterinario veterinario = _appContext.Veterinarios
            .Include(p => p.Persona.Direccion)
            .Include(p => p.Visitas)
            .FirstOrDefault(p => p.Persona.PersonaID == visita.VeterinarioID);
            Porcino porcino = _appContext.Porcinos
            .Include(p => p.Propietario.Persona.Direccion)
            .Include(p => p.Visitas)
            .Include(p => p.HistoriaClinica.Visitas)
            .FirstOrDefault(p => p.PorcinoID == visita.PorcinoID);
            if (veterinario != null && porcino != null)
            {
                veterinario.Visitas.Add(visita);
                porcino.Visitas.Add(visita);
                porcino.HistoriaClinica.Visitas.Add(visita);
                _appContext.SaveChanges();
                return visita;
            }
            return null;
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