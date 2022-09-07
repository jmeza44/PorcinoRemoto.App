using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioVisita
    {
        IEnumerable<Visita> GetAllVisitas();
        Visita GetVisita(int idVisita);
        Visita AddVisita(Visita visita);
        Visita UpdateVisita(Visita visita);
        void DeleteVisita(int idVisita);
    }
}