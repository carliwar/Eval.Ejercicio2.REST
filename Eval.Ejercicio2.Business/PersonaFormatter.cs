using Eval.Ejercicio2.Core.Interfaces;
using Eval.Ejercicio2.Core.Models;
using System;

namespace Eval.Ejercicio2.Business
{
    public class PersonaFormatter : IPersonaFormatter
    {
        public string FormatPersona(Persona persona)
        {
            return $"{persona.Nombre} {persona.Apellido}";
        }
    }
}
