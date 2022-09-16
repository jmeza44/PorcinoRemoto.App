using System.Collections.Generic;
using System.Linq;
using PorcinoRemoto.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        List<Veterinario> IRepositorioVeterinario.GetAllVeterinario()
        {
            return _appContext.Veterinarios
            .Include(p => p.Persona.Direccion)
            .ToList();
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(string idPersona)
        {
            return _appContext.Veterinarios
            .Include(p => p.Persona.Direccion)
            .FirstOrDefault(p => p.Persona.PersonaID == idPersona);
        }

        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var VeterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return VeterinarioAdicionado.Entity;
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.Persona.PersonaID == veterinario.Persona.PersonaID);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Persona.PrimerNombre = veterinario.Persona.PrimerNombre;
                veterinarioEncontrado.Persona.SegundoNombre = veterinario.Persona.SegundoNombre;
                veterinarioEncontrado.Persona.PrimerApellido = veterinario.Persona.PrimerApellido;
                veterinarioEncontrado.Persona.SegundoApellido = veterinario.Persona.SegundoApellido;
                veterinarioEncontrado.Persona.Direccion = veterinario.Persona.Direccion;
                veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;

                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }

        void IRepositorioVeterinario.DeleteVeterinario(string idPersona)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.Persona.PersonaID == idPersona);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();

        }

    }
}