using PorcinoRemoto.App.Dominio;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioPersona
    {
        List<Persona> GetAllPersonas();
        Persona GetPersona(string idPersona);
        Persona AddPersona(Persona persona);
        Persona UpdatePersona(Persona persona);
        void DeletePersona(string idPersona);
    }
}