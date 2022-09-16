using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioPorcino : IRepositorioPorcino
    {
        private readonly AppContext _appContext;
        public RepositorioPorcino(AppContext appContext)
        {
            _appContext = appContext;
        }

        List<Porcino> IRepositorioPorcino.GetAllPorcinos()
        {
            return _appContext.Porcinos
            .Include(p => p.Propietario.Persona.Direccion)
            .Include(p => p.HistoriaClinica)
            .ToList();
        }

        Porcino IRepositorioPorcino.GetPorcino(int idPorcino)
        {
            return _appContext.Porcinos
            .Include(p => p.Propietario.Persona.Direccion)
            .Include(p => p.HistoriaClinica)
            .FirstOrDefault(p => p.PorcinoID == idPorcino);
        }

        Porcino IRepositorioPorcino.AddPorcino(Porcino porcino)
        {
            Propietario propietario = _appContext.Propietarios
            .Include(p => p.Persona.Direccion)
            .Include(p => p.Porcinos)
            .FirstOrDefault(p => p.Persona.PersonaID == porcino.Propietario.Persona.PersonaID); ;
            if (propietario != null)
            {
                propietario.Porcinos.Add(porcino);
                return porcino;
            }
            else
            {
                var porcinoAdicionado = _appContext.Porcinos.Add(porcino);
                return porcinoAdicionado.Entity;
            }

            _appContext.SaveChanges();
        }

        Porcino IRepositorioPorcino.UpdatePorcino(Porcino porcino)
        {
            var porcinoEncontrado = _appContext.Porcinos.FirstOrDefault(p => p.PorcinoID == porcino.PorcinoID);
            if (porcinoEncontrado != null)
            {
                porcinoEncontrado.Nombre = porcino.Nombre;
                porcinoEncontrado.Color = porcino.Color;
                porcinoEncontrado.Especie = porcino.Especie;
                porcinoEncontrado.Raza = porcino.Raza;
                porcinoEncontrado.Propietario = porcino.Propietario;
                porcinoEncontrado.HistoriaClinica = porcino.HistoriaClinica;

                _appContext.SaveChanges();
            }
            return porcinoEncontrado;
        }

        void IRepositorioPorcino.DeletePorcino(int idPorcino)
        {
            var porcinoEncontrado = _appContext.Porcinos.FirstOrDefault(p => p.PorcinoID == idPorcino);
            if (porcinoEncontrado == null)
                return;
            _appContext.Porcinos.Remove(porcinoEncontrado);
            _appContext.SaveChanges();

        }

    }
}