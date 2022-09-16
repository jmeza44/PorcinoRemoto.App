using PorcinoRemoto.App.Dominio;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioPropietario
    {
        List<Propietario> GetAllPropietario();
        Propietario GetPropietario(string idPersona);
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario );
        void DeletePropietario(string idPersona);
        
    }
}