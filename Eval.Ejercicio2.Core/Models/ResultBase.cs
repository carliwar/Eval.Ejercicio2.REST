using System.Collections.Generic;
using System.Linq;

namespace Eval.Ejercicio2.Core.Models
{
    public class ResultBase
    {
        public List<string> ErrorMessages { get; set; }
        public bool Success
        {
            get
            {
                return ErrorMessages.Count() == 0;
            }
        }
    }
}
