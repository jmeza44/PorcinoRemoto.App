using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioPersona
    {
        IEnumerable<Persona> GetAllPersonas();
        Persona GetPersona(int idPersona);
        Persona AddPersona(Persona persona);
        Persona UpdatePersona(Persona persona);
        void DeletePersona(int idPersona);
    }
}