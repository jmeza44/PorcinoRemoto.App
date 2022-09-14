using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioPorcino : IRepositorioPorcino
    {
        private readonly AppContext _appContext;
        public RepositorioPorcino(AppContext appContext)
        {
            _appContext = appContext;
        }

        IEnumerable<Porcino> IRepositorioPorcino.GetAllPorcinos()
        {
            return _appContext.Porcinos;
        }

        Porcino IRepositorioPorcino.GetPorcino(int idPorcino)
        {
            return _appContext.Porcinos.FirstOrDefault(p => p.PorcinoID == idPorcino);
        }

        Porcino IRepositorioPorcino.AddPorcino(Porcino porcino)
        {
            var porcinoAdicionado = _appContext.Porcinos.Add(porcino);
            _appContext.SaveChanges();
            return porcinoAdicionado.Entity;
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