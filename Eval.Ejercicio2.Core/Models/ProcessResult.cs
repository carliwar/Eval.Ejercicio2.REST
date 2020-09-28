using System.Collections.Generic;

namespace Eval.Ejercicio2.Core.Models
{
    public class ProcessResult
    {
        public ProcessResult()
        {
            PersonasMujeresMayoresDe18 = new List<string>();
        }

        public string ErrorMessage { get; set; }
        public bool Success
        {
            get
            {
                return ErrorMessage == null;
            }
        }

        public List<string> PersonasMujeresMayoresDe18 { get; set; }
    }
}
