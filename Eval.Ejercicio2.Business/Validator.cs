using Eval.Ejercicio2.Core.Interfaces;
using Eval.Ejercicio2.Core.Models;

namespace Eval.Ejercicio2.Business
{
    public class Validator : IValidator
    {
        public PersonasResult ValidateInputList(PersonaRequest persona)
        {
            var result = new PersonasResult();
            if (persona == null || persona.Personas == null || persona.Personas.Count < 1)
            {
                result.ErrorMessages.Add("Ingresar al menos 1 persona.");
            }
            return result;
        }

        public ValidatePersonaResult ValidatePersona(Persona persona)
        {
            var result = new ValidatePersonaResult();

            if(persona.Nombre == null)
            {
                result.ErrorMessages.Add("El nombre es requerido.");
            }

            if (persona.Apellido == null)
            {
                result.ErrorMessages.Add("El apellido es requerido.");
            }

            if (persona.Edad == null)
            {
                result.ErrorMessages.Add("La edad es requerida.");
            }

            if (persona.Sexo == null)
            {
                result.ErrorMessages.Add("El sexo es requerido.");
            }

            return result;
        }
    }
}
