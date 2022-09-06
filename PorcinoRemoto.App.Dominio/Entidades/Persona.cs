namespace PorcinoRemoto.App.Dominio
{
    public class Persona
    {
        public string id { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Direccion direccion { get; set; }

        public Persona(string id, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, Direccion direccion)
        {
            this.id = id;
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.direccion = direccion;
        }
    }
}