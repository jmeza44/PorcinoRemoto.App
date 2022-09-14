using System.ComponentModel.DataAnnotations;
namespace PorcinoRemoto.App.Dominio
{
    public class Veterinario
    {
        [Key]
        public string TarjetaProfesional { get; set; }
        public Persona Persona { get; set; }
    }
}