using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioPropietario
    {
        IEnumerable<Propietario> GetAllPropietario();
        Propietario GetPropietario(string idPersona);
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario );
        void DeletePropietario(string idPersona);
        
    }
}