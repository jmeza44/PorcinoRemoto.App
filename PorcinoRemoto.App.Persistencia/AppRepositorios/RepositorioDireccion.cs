using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Linq;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioDireccion : IRepositorioDireccion
    {
        private readonly AppContext _appContext;
        public RepositorioDireccion(AppContext appContext)
        {
            _appContext = appContext;
        }

        IEnumerable<Direccion> IRepositorioDireccion.GetAllDireccion()
        {
            return _appContext.Direcciones;
        }

        Direccion IRepositorioDireccion.GetDireccion(int idDireccion)
        {
            return _appContext.Direcciones.FirstOrDefault(p => p.DireccionID == idDireccion);
        }

        Direccion IRepositorioDireccion.AddDireccion(Direccion direccion)
        {
            var direccionAdicionada = _appContext.Direcciones.Add(direccion);
            _appContext.SaveChanges();
            return direccionAdicionada.Entity;
        }

        Direccion IRepositorioDireccion.UpdateDireccion(Direccion direccion)
        {
            var direccionEncontrada = _appContext.Direcciones.FirstOrDefault(p => p.DireccionID == direccion.DireccionID);
            if (direccionEncontrada != null)
            {
                direccionEncontrada.Carrera = direccion.Carrera;
                direccionEncontrada.Calle = direccion.Calle;
                direccionEncontrada.Numero = direccion.Numero;
                direccionEncontrada.Ciudad = direccion.Ciudad;
                direccionEncontrada.Departamento = direccion.Departamento;

                _appContext.SaveChanges();
            }
            return direccionEncontrada;
        }

        void IRepositorioDireccion.DeleteDireccion(int idDireccion)
        {
            var direccionEncontrada = _appContext.Direcciones.FirstOrDefault(p => p.DireccionID == idDireccion);
            if (direccionEncontrada == null)
                return;
            _appContext.Direcciones.Remove(direccionEncontrada);
            _appContext.SaveChanges();

        }

    }
}