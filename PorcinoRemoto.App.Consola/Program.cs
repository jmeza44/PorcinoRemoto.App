using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PorcinoRemoto.App.Consola
{
    public class Program
    {
        private static IRepositorioPersona _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
        public static async Task Main(string[] args)
        {
            // Persona personaCreando = new Persona
            // {
            //     PersonaID = "100297582144",
            //     PrimerNombre = "Lucho",
            //     SegundoNombre = "",
            //     PrimerApellido = "Fernandez",
            //     SegundoApellido = "",
            //     Direccion = new Direccion
            //     {
            //         Carrera = "12",
            //         Calle = "64",
            //         Numero = "3",
            //         Ciudad = "null",
            //         Departamento = "null",
            //     }
            // };

            var personaEncontrada = await _repoPersona.GetPersona("100297582144");
            if (personaEncontrada != null)
            {
                Console.WriteLine("Persona encontrada!");
                Console.WriteLine(personaEncontrada);
            }
            else
            {
                Console.WriteLine("Persona no encontrada!");
            }
        }

        private static void AddPersona(Persona persona)
        {
            Console.WriteLine("Agregando una persona!");
            _repoPersona.AddPersona(persona);
            Console.WriteLine("Persona agregada!");
        }

        private static async Task<Persona> BuscarPersona(string idPersona)
        {
            Console.WriteLine("Buscando una persona!");
            var persona = await _repoPersona.GetPersona(idPersona);
            return persona;
        }

        private static IEnumerable<Persona> BuscarPersonas()
        {
            Console.WriteLine("Buscando todas las personas!");
            return _repoPersona.GetAllPersonas();
        }
    }
}