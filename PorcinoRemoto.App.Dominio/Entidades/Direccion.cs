using System.Runtime.CompilerServices;

namespace PorcinoRemoto.App.Dominio
{
    public class Direccion
    {
        public string carrera { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }

        public Direccion(string carrera, string calle, string numero, string ciudad, string departamento)
        {
            this.carrera = carrera;
            this.calle = calle;
            this.numero = numero;
            this.ciudad = ciudad;
            this.departamento = departamento;
        }
    }
}