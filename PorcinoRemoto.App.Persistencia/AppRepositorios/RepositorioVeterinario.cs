using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Linq;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinario()
        {
            return _appContext.Veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(p => p.PersonaID == idVeterinario);
        }

        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var VeterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return VeterinarioAdicionado.Entity;
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.PersonaID == veterinario.PersonaID);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.PrimerNombre = veterinario.PrimerNombre;
                veterinarioEncontrado.SegundoNombre = veterinario.SegundoNombre;
                veterinarioEncontrado.PrimerApellido = veterinario.PrimerApellido;
                veterinarioEncontrado.SegundoApellido = veterinario.SegundoApellido;
                veterinarioEncontrado.Direccion = veterinario.Direccion;
                veterinarioEncontrado.TarjetaProfesional=veterinario.TarjetaProfesional;

                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.PersonaID == idVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();

        }

    }
}