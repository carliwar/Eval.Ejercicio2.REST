using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eval.Ejercicio2.Client
{
    public class PersonaRequestModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Edad { get; set; }
        public string Sexo { get; set; }
    }

    public class Error
    {
        public string Message { get; set; }
    }
}
