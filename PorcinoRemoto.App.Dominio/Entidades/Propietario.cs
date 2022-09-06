namespace PorcinoRemoto.App.Dominio
{
    public class Propietario : Persona
    {
        public string email { get; set; }

        public Propietario(string id, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, Direccion direccion, string email) : base(id, primerNombre, segundoNombre, primerApellido, segundoApellido, direccion)
        {
            this.email = email;
        }
    }
}