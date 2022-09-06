using System;

namespace HospitalEnCasa.App.Dominio
{
    public class Registro
    {
        public string Id { get; set; }
        public Persona Autor { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
