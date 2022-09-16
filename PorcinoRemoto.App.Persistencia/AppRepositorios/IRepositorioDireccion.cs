using PorcinoRemoto.App.Dominio;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioDireccion
    {
        List<Direccion> GetAllDireccion();
        Direccion GetDireccion(int idDireccion);
        Direccion AddDireccion(Direccion direccion);
        Direccion UpdateDireccion(Direccion direccion );
        void DeleteDireccion(int idDireccion);
        
    }
}