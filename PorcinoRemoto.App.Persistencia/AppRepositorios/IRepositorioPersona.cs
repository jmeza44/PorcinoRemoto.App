using System.Threading.Tasks;
using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioPersona
    {
        List<Persona> GetAllPersonas();
        Task<Persona> GetPersona(string idPersona);
        Persona AddPersona(Persona persona);
        Persona UpdatePersona(Persona persona);
        void DeletePersona(string idPersona);
    }
}