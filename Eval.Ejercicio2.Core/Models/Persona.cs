namespace Eval.Ejercicio2.Core.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Edad { get; set; }
        public Sexo? Sexo { get; set; }
    }

    public enum Sexo
    {
        F,
        M
    }
}
