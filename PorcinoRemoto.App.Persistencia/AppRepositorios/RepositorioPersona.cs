using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Linq;
using System;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly AppContext _appContext;
        public RepositorioPersona(AppContext appContext)
        {
            _appContext = appContext;
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersonas()
        {
            return _appContext.Personas;
        }

        Persona IRepositorioPersona.GetPersona(int idPersona)
        {
            Console.WriteLine("Entrada" + idPersona);
            using (var context = new AppContext())
            {
            var persona = context.Personas
                .Where(w => w.PersonaID == idPersona)
                .FirstOrDefault();
            Console.WriteLine("Paso");
        
            return persona;
            }
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

        void IRepositorioPersona.DeletePersona(int idPersona)
        {
            var personaEncontrada = _appContext.Personas.FirstOrDefault(p => p.PersonaID == idPersona);
            if (personaEncontrada == null)
                return;
            _appContext.Personas.Remove(personaEncontrada);
            _appContext.SaveChanges();

        }

    }
}