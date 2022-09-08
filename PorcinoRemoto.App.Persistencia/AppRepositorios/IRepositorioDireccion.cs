using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioDireccion
    {
        IEnumerable<Direccion> GetAllDireccion();
        Direccion GetDireccion(int idDireccion);
        Direccion AddDireccion(Direccion direccion);
        Direccion UpdateDireccion(Direccion direccion );
        void DeleteDireccion(int idDireccion);
        
    }
}