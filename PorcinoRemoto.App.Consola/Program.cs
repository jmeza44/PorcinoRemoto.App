using PorcinoRemoto.App.Dominio;
using PorcinoRemoto.App.Persistencia;
using System;
using System.Collections.Generic;
namespace PorcinoRemoto.App.Consola
{
    public class Program
    {
        private static IRepositorioPersona _repoPersona = new RepositorioPersona(new Persistencia.AppContext());
        private static IRepositorioPorcino _repoPorcino = new RepositorioPorcino(new Persistencia.AppContext());
        public static void Main(string[] args)
        {
            Porcino porcinoEncontrado = BuscarPorcino(1);
            if (porcinoEncontrado != null)
            {
                Console.Write(
                porcinoEncontrado.PorcinoID +
                "\t" + porcinoEncontrado.Nombre +
                "\t" + porcinoEncontrado.Color +
                "\t" + porcinoEncontrado.Especie +
                "\t" + porcinoEncontrado.Raza +
                "\n" + "Propietario:\n" +
                porcinoEncontrado.Propietario.Email +
                "\n" + "Persona:\n" +
                porcinoEncontrado.Propietario.Persona.PersonaID +
                "\t" + porcinoEncontrado.Propietario.Persona.PrimerNombre +
                "\t" + porcinoEncontrado.Propietario.Persona.SegundoNombre +
                "\t" + porcinoEncontrado.Propietario.Persona.PrimerApellido +
                "\t" + porcinoEncontrado.Propietario.Persona.SegundoApellido +
                "\n" + "Direccion:\n" +
                porcinoEncontrado.Propietario.Persona.Direccion.DireccionID +
                "\t" + porcinoEncontrado.Propietario.Persona.Direccion.Carrera +
                "\t" + porcinoEncontrado.Propietario.Persona.Direccion.Calle +
                "\t" + porcinoEncontrado.Propietario.Persona.Direccion.Numero +
                "\t" + porcinoEncontrado.Propietario.Persona.Direccion.Ciudad +
                "\t" + porcinoEncontrado.Propietario.Persona.Direccion.Departamento +
                "\n" + "Historia Clinica:\n" +
                porcinoEncontrado.HistoriaClinica.HistoriaID +
                "\t" + porcinoEncontrado.HistoriaClinica.FechaGeneracion
                );
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
        private static void AddPorcino(Porcino porcino)
        {
            Console.WriteLine("Agregando un porcino!");
            _repoPorcino.AddPorcino(porcino);
            Console.WriteLine("Porcino agregado!");
        }
        private static Porcino BuscarPorcino(int idPorcino)
        {
            Console.WriteLine("Buscando un porcino!");
            return _repoPorcino.GetPorcino(idPorcino);
        }

        private static List<Porcino> BuscarPorcinos()
        {
            Console.WriteLine("Buscando todos los porcinos!");
            return _repoPorcino.GetAllPorcinos();
        }

        private static void MostrarInfoPersona(Persona persona)
        {
            Console.Write(
                persona.PersonaID +
                "\t" + persona.PrimerNombre +
                "\t" + persona.SegundoNombre +
                "\t" + persona.PrimerApellido +
                "\t" + persona.SegundoApellido +
                "\t" + persona.Direccion.DireccionID +
                "\t" + persona.Direccion.Carrera +
                "\t" + persona.Direccion.Calle +
                "\t" + persona.Direccion.Numero +
                "\t" + persona.Direccion.Ciudad +
                "\t" + persona.Direccion.Departamento
                );
        }
    }
}