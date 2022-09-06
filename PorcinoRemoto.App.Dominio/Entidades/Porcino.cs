namespace PorcinoRemoto.App.Dominio
{
    public class Porcino
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }
        public Propietario propietario { get; set; }

        public Porcino(string id, string nombre, string color, string especie, string raza, Propietario propietario)
        {
            this.id = id;
            this.nombre = nombre;
            this.color = color;
            this.especie = especie;
            this.raza = raza;
            this.propietario = propietario;
        }
    }
}