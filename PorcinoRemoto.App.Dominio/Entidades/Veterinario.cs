namespace PorcinoRemoto.App.Dominio
{
    public class Veterinario : Persona
    {
        public string tarjetaProfesional { get; set; }

        public Veterinario(string id, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, Direccion direccion, string tarjetaProfesional) : base(id, primerNombre, segundoNombre, primerApellido, segundoApellido, direccion)
        {
            this.tarjetaProfesional = tarjetaProfesional;
        }
    }
}