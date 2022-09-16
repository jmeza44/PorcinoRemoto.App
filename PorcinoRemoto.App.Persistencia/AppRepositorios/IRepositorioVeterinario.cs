using PorcinoRemoto.App.Dominio;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        List<Veterinario> GetAllVeterinario();
        Veterinario GetVeterinario(string idPersona);
        Veterinario AddVeterinario(Veterinario veterinario);
        Veterinario UpdateVeterinario(Veterinario veterinario );
        void DeleteVeterinario(string idPersona);
        
    }
}