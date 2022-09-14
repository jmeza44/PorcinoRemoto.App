using PorcinoRemoto.App.Dominio;
namespace PorcinoRemoto.App.Persistencia
{
    public interface IRepositorioPorcino
    {
        List<Porcino> GetAllPorcinos();
        Porcino GetPorcino(int idPorcino);
        Porcino AddPorcino(Porcino porcino);
        Porcino UpdatePorcino(Porcino porcino);
        void DeletePorcino(int idPorcino);
    }
}