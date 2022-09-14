using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Consola
{
    public class Program
    {
        private static IRepositorioPersona _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
        public static void Main(string[] args)
        {
            Persona personaCreando = new Persona
            {
                PersonaID = "1003826586",
                PrimerNombre = "Pinel",
                SegundoNombre = "Bill",
                PrimerApellido = "Orslok",
                SegundoApellido = "Luyan",
                Direccion = new Direccion
                {
                    Carrera = "54B",
                    Calle = "15",
                    Numero = "6",
                    Ciudad = "Barranquilla",
                    Departamento = "Atlantico",
                }
            };

            // Uso de la adición a la base de datos
            // AddPersona(personaCreando);

            // Uso de la búsqueda completa en la base de datos
            List<Persona> personas = BuscarPersonas();
            if (personas != null)
            {
                if (personas.Count() > 0)
                {
                    int i = 1;
                    foreach (var persona in personas)
                    {
                        Console.WriteLine(i + ". " + persona.PersonaID);
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("Empty");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }

            // Uso de la búsqueda individual
            Persona personaEncontrada = _repoPersona.GetPersona("1003826586");
            if (personaEncontrada != null)
            {
                Console.WriteLine("Persona encontrada!");
                Console.WriteLine("ID: " + personaEncontrada.PersonaID);
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

        private static Persona BuscarPersona(string idPersona)
        {
            Console.WriteLine("Buscando una persona!");
            return _repoPersona.GetPersona(idPersona);
        }

        private static List<Persona> BuscarPersonas()
        {
            Console.WriteLine("Buscando todas las personas!");
            return _repoPersona.GetAllPersonas();
        }
    }
}