using Eval.Ejercicio2.Core.Models;

namespace Eval.Ejercicio2.Core.Interfaces
{
    public interface IValidator
    {
        PersonasResult ValidateInputList(PersonaRequest persona);
        ValidatePersonaResult ValidatePersona(Persona persona);
    }
}
