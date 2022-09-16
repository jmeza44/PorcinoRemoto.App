using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _appContext;
        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }

        List<Propietario> IRepositorioPropietario.GetAllPropietario()
        {
            return _appContext.Propietarios
            .Include(p => p.Persona.Direccion)
            .ToList();
        }

        Propietario IRepositorioPropietario.GetPropietario(string idPersona)
        {
            return _appContext.Propietarios
            .Include(p => p.Persona.Direccion)
            .FirstOrDefault(p => p.Persona.PersonaID == idPersona);
        }

        Propietario IRepositorioPropietario.AddPropietario(Propietario propietario)
        {
            var propietarioAdicionado = _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        Propietario IRepositorioPropietario.UpdatePropietario(Propietario propietario)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Persona.PersonaID == propietario.Persona.PersonaID);
            if (propietarioEncontrado != null)
            {
                propietarioEncontrado.Persona.PrimerNombre = propietario.Persona.PrimerNombre;
                propietarioEncontrado.Persona.SegundoNombre = propietario.Persona.SegundoNombre;
                propietarioEncontrado.Persona.PrimerApellido = propietario.Persona.PrimerApellido;
                propietarioEncontrado.Persona.SegundoApellido = propietario.Persona.SegundoApellido;
                propietarioEncontrado.Persona.Direccion = propietario.Persona.Direccion;
                propietarioEncontrado.Email = propietario.Email;

                _appContext.SaveChanges();
            }
            return propietarioEncontrado;
        }

        void IRepositorioPropietario.DeletePropietario(string idPersona)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Persona.PersonaID == idPersona);
            if (propietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(propietarioEncontrado);
            _appContext.SaveChanges();

        }

    }
}