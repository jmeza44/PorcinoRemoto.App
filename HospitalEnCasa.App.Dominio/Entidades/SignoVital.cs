namespace HospitalEnCasa.App.Dominio
{
    public class SignoVital : Registro
    {
        public enum Signo
        {
            oximetria,
            frecuenciaRespiratoria,
            frecuenciaCardiaca,
            temperatura,
            presionArterial,
            glicemias
        }
        public double Valor { get; set; }
    }
}
