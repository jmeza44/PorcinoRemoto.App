using System.Runtime.Serialization;
using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;

namespace PorcinoRemoto.App.Consola
{
    public class Program
    {
        private static IRepositorioPersona _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
        public static void Main(string[] args)
        {
            Persona personaCreando = new Persona
            {
                PersonaID = 4,
                PrimerNombre = "Lucho",
                SegundoNombre = "",
                PrimerApellido = "Fernandez",
                SegundoApellido = "",
                Direccion = new Direccion
                {
                    Carrera = "",
                    Calle = "",
                    Numero = "",
                    Ciudad = "",
                    Departamento = "",
                }
            };

            _repoPersona.UpdatePersona(personaCreando);

            /* Persona personaEncontrada = BuscarPersona(1);
            if (personaEncontrada != null)
                Console.WriteLine("Persona encontrada: " + personaEncontrada.PrimerNombre); */
        }

        private static void AddPersona(Persona persona)
        {
            Console.WriteLine("Agregando una persona!");
            _repoPersona.AddPersona(persona);
            Console.WriteLine("Persona agregada!");
        }

        private static Persona BuscarPersona(int idPersona)
        {
            Console.WriteLine("Buscando una persona!");
            return _repoPersona.GetPersona(idPersona);
        }
    }
}