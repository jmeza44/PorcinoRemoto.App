using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Linq;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _appContext;
        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }

        IEnumerable<Propietario> IRepositorioPropietario.GetAllPropietario()
        {
            return _appContext.Propietarios;
        }

        Propietario IRepositorioPropietario.GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(p => p.PersonaID == idPropietario);
        }

        Propietario IRepositorioPropietario.AddPropietario(Propietario propietario)
        {
            var propietarioAdicionado = _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        Propietario IRepositorioPropietario.UpdatePropietario(Propietario propietario)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.PersonaID == propietario.PersonaID);
            if (propietarioEncontrado != null)
            {
                propietarioEncontrado.PrimerNombre = propietario.PrimerNombre;
                propietarioEncontrado.SegundoNombre =propietario.SegundoNombre;
                propietarioEncontrado.PrimerApellido = propietario.PrimerApellido;
                propietarioEncontrado.SegundoApellido = propietario.SegundoApellido;
                propietarioEncontrado.Direccion = propietario.Direccion;
                propietarioEncontrado.Email=propietario.Email;

                _appContext.SaveChanges();
            }
            return propietarioEncontrado;
        }

        void IRepositorioPropietario.DeletePropietario(int idPropietario)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.PersonaID == idPropietario);
            if (propietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(propietarioEncontrado);
            _appContext.SaveChanges();

        }

    }
}