using Eval.Ejercicio2.Business;
using Eval.Ejercicio2.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Eval.Ejercicio2.Tests
{
    [TestClass]
    public class ValidatorTests
    {        
        [TestMethod]
        public void ValidateInput_NullValue_ReturnsError()
        {
            //Arrange            
            PersonaRequest personaRequests = null;
            var validator = new Validator();

            //Act
            PersonasResult result = validator.ValidateInputList(personaRequests);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.ErrorMessages.Count());
            Assert.AreEqual("Ingresar al menos 1 persona.", result.ErrorMessages.First());
        }

        [TestMethod]
        public void ValidateInput_NotNullRequestNullListValue_ReturnsError()
        {
            //Arrange            
            var personaRequests = new PersonaRequest();
            var validator = new Validator();

            //Act
            PersonasResult result = validator.ValidateInputList(personaRequests);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.ErrorMessages.Count());
            Assert.AreEqual("Ingresar al menos 1 persona.", result.ErrorMessages.First());

        }

        [TestMethod]
        public void ValidateInput_NotNullRequestEmptyValue_ReturnsError()
        {
            //Arrange            
            var personaRequests = new PersonaRequest
            {
                Personas = new List<Persona>()
            };
            var validator = new Validator();

            //Act
            PersonasResult result = validator.ValidateInputList(personaRequests);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.ErrorMessages.Count());
            Assert.AreEqual("Ingresar al menos 1 persona.", result.ErrorMessages.First());
        }

        [TestMethod]
        public void ValidatePersona_NullNombre_ReturnsError()
        {
            //Arrange            
            var persona = new Persona
            {
                Apellido = "apellido",
                Edad = 10,
                Sexo = Sexo.F
            };
            var validator = new Validator();

            //Act
            ValidatePersonaResult result = validator.ValidatePersona(persona);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.ErrorMessages.Count());
            Assert.AreEqual("El nombre es requerido.", result.ErrorMessages.First());
        }

        [TestMethod]
        public void ValidatePersona_NullApellido_ReturnsError()
        {
            //Arrange            
            var persona = new Persona
            {
                Nombre = "name",
                Edad = 11,
                Sexo = Sexo.F

            };
            var validator = new Validator();

            //Act
            ValidatePersonaResult result = validator.ValidatePersona(persona);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.ErrorMessages.Count());
            Assert.AreEqual("El apellido es requerido.", result.ErrorMessages.First());
        }

        [TestMethod]
        public void ValidatePersona_NullEdad_ReturnsError()
        {
            //Arrange            
            var persona = new Persona
            {
                Nombre = "name",
                Apellido = "apellido",
                Sexo = Sexo.F
            };
            var validator = new Validator();

            //Act
            ValidatePersonaResult result = validator.ValidatePersona(persona);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.ErrorMessages.Count());
            Assert.AreEqual("La edad es requerida.", result.ErrorMessages.First());
        }

        [TestMethod]
        public void ValidatePersona_NullSexo_ReturnsError()
        {
            //Arrange            
            var persona = new Persona
            {
                Nombre = "name",
                Apellido = "apellido",
                Edad = 10
            };
            var validator = new Validator();

            //Act
            ValidatePersonaResult result = validator.ValidatePersona(persona);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.ErrorMessages.Count());
            Assert.AreEqual("El sexo es requerido.", result.ErrorMessages.First());
        }

    }
}
