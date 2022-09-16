using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;
using Microsoft.EntityFrameworkCore;
namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly AppContext _appContext;
        public RepositorioPersona(AppContext appContext)
        {
            _appContext = appContext;
        }

        List<Persona> IRepositorioPersona.GetAllPersonas()
        {
            return _appContext.Personas
            .Include(p => p.Direccion)
            .ToList();
        }

        Persona IRepositorioPersona.GetPersona(string idPersona)
        {
            return _appContext.Personas
            .Include(p => p.Direccion)
            .FirstOrDefault(p => p.PersonaID == idPersona);
        }

        Persona IRepositorioPersona.AddPersona(Persona persona)
        {
            var personaAdicionada = _appContext.Personas.Add(persona);
            _appContext.SaveChanges();
            return personaAdicionada.Entity;
        }

        Persona IRepositorioPersona.UpdatePersona(Persona persona)
        {
            var personaEncontrada = _appContext.Personas.FirstOrDefault(p => p.PersonaID == persona.PersonaID);
            if (personaEncontrada != null)
            {
                personaEncontrada.PrimerNombre = persona.PrimerNombre;
                personaEncontrada.SegundoNombre = persona.SegundoNombre;
                personaEncontrada.PrimerApellido = persona.PrimerApellido;
                personaEncontrada.SegundoApellido = persona.SegundoApellido;
                personaEncontrada.Direccion = persona.Direccion;

                _appContext.SaveChanges();
            }
            return personaEncontrada;
        }

        void IRepositorioPersona.DeletePersona(string idPersona)
        {
            var personaEncontrada = _appContext.Personas.FirstOrDefault(p => p.PersonaID == idPersona);
            if (personaEncontrada == null)
                return;
            _appContext.Personas.Remove(personaEncontrada);
            _appContext.SaveChanges();

        }

    }
}