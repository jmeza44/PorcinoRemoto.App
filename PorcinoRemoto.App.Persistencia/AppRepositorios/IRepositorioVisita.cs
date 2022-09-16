using PorcinoRemoto.App.Dominio;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioVisita
    {
        List<Visita> GetAllVisitas();
        Visita GetVisita(int idVisita);
        Visita AddVisita(Visita visita);
        Visita UpdateVisita(Visita visita);
        void DeleteVisita(int idVisita);
    }
}