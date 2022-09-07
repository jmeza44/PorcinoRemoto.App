using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioPorcino
    {
        IEnumerable<Porcino> GetAllPorcinos();
        Porcino GetPorcino(int idPorcino);
        Porcino AddPorcino(Porcino porcino);
        Porcino UpdatePorcino(Porcino porcino);
        void DeletePorcino(int idPorcino);
    }
}