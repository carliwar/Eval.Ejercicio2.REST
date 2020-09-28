using Eval.Ejercicio2.Core.Interfaces;
using Eval.Ejercicio2.Core.Models;
using System;

namespace Eval.Ejercicio2.Business
{
    public class PersonasProcessor
    {
        private readonly IValidator PersonaValidator;
        private readonly IPersonaFormatter PersonaFormatter;

        public PersonasProcessor(IValidator personaValidator, IPersonaFormatter personaFormatter)
        {
            PersonaValidator = personaValidator;
            PersonaFormatter = personaFormatter;
        }

        public ProcessResult Process(PersonaRequest personaRequest)
        {
            var processResult = new ProcessResult();

            PersonasResult validationResult = PersonaValidator.ValidateInputList(personaRequest);

            if (!validationResult.Success)
            {
                string erroresString = String.Join("\n", validationResult.ErrorMessages);
                processResult.ErrorMessage = $"El proceso no puede ser completado. Error: " +
                    $"{erroresString}";
            }
            else
            {
                string erroresString = null;

                foreach (var persona in personaRequest.Personas)
                {
                    ValidatePersonaResult validatePersonaResult = PersonaValidator.ValidatePersona(persona);                    

                    if (validatePersonaResult.Success)
                    {
                        if (persona.Sexo == Sexo.F && persona.Edad > 17)
                        {
                            processResult.PersonasMujeresMayoresDe18
                                .Add(PersonaFormatter.FormatPersona(persona));
                        }
                    }
                    else
                    {                        
                        erroresString = string.Join("\n", validatePersonaResult.ErrorMessages);
                    }                    
                }
                
                if(!string.IsNullOrEmpty(erroresString))
                {
                    processResult.ErrorMessage = $"El proceso no puede ser completado. Error: {erroresString}";
                }
            }
            return processResult;
        }
    }
}
