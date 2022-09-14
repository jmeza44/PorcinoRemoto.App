using System.ComponentModel.DataAnnotations;
namespace PorcinoRemoto.App.Dominio
{
    public class Propietario
    {
        [Key]
        public string Email { get; set; }
        public Persona Persona { get; set; }
    }
}