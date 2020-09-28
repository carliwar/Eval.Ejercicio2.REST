using Eval.Ejercicio2.Business;
using Eval.Ejercicio2.Core.Interfaces;
using Eval.Ejercicio2.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace Eval.Ejercicio2.Tests
{
    [TestClass]
    public class PersonaProcessorTests
    {
        [TestMethod]
        public void ProcessPersona_NotValidInput_ReturnsErrorStatus()
        {
            //Arrange
            var personaValidator = Substitute.For<IValidator>();
            var personaFormatter = Substitute.For<IPersonaFormatter>();
            var personaProcessor = new PersonasProcessor(personaValidator, personaFormatter);
            var personaRequest = new PersonaRequest
            {
                Personas = null
            };
            var personasResult = new PersonasResult
            {
                ErrorMessages = new List<string>
                {
                    "Ingresar al menos 1 persona."
                }
            };

            personaValidator.ValidateInputList(personaRequest).Returns(personasResult);

            //Act
            ProcessResult result = personaProcessor.Process(personaRequest);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("El proceso no puede ser completado. Error: Ingresar al menos 1 persona.",
                result.ErrorMessage);
        }

        [TestMethod]
        public void ProcessPersona_ValidInputUnderagePerson_Returns0Values()
        {
            //Arrange
            var personaValidator = Substitute.For<IValidator>();
            var personaFormatter = Substitute.For<IPersonaFormatter>();
            var personasProcessor = new PersonasProcessor(personaValidator, personaFormatter);
            var persona = new Persona
            {
                Nombre = "Rosa",
                Apellido = "Benitez",
                Sexo = Sexo.F,
                Edad = 17
            };

            var personaRequest = new PersonaRequest
            {
                Personas = new List<Persona>
                    {
                        persona
                    }
            };
            var validationResult = new PersonasResult();

            personaValidator.ValidateInputList(personaRequest).Returns(validationResult);

            //Act
            ProcessResult result = personasProcessor.Process(personaRequest);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(0, result.PersonasMujeresMayoresDe18.Count());
        }

        [TestMethod]
        public void ProcessPersona_ValidInputMasculinePersona_Returns0Values()
        {
            //Arrange
            var personaValidator = Substitute.For<IValidator>();
            var personaFormatter = Substitute.For<IPersonaFormatter>();
            var personasProcessor = new PersonasProcessor(personaValidator, personaFormatter);
            var persona = new Persona
            {
                Nombre = "Rosa",
                Apellido = "Benitez",
                Sexo = Sexo.M,
                Edad = 20
            };

            var personaRequest = new PersonaRequest
            {
                Personas = new List<Persona>
                    {
                        persona
                    }
            };
            var validationResult = new PersonasResult();

            personaValidator.ValidateInputList(personaRequest).Returns(validationResult);

            //Act
            ProcessResult result = personasProcessor.Process(personaRequest);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(0, result.PersonasMujeresMayoresDe18.Count());
        }

        [TestMethod]
        public void ProcessPersona_ValidInput_Returns1Value()
        {
            //Arrange
            var personaValidator = Substitute.For<IValidator>();
            var personaFormatter = Substitute.For<IPersonaFormatter>();
            var personasProcessor = new PersonasProcessor(personaValidator, personaFormatter);
            var persona = new Persona
            {
                Nombre = "Rosa",
                Apellido = "Benitez",
                Sexo = Sexo.F,
                Edad = 20
            };

            var personaRequest = new PersonaRequest
            {
                Personas = new List<Persona>
                    {
                        persona
                    }
            };
            var validationResult = new PersonasResult();

            personaValidator.ValidateInputList(personaRequest).Returns(validationResult);
            personaFormatter.FormatPersona(Arg.Any<Persona>()).Returns("Rosa Benitez");

            //Act
            ProcessResult result = personasProcessor.Process(personaRequest);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(1, result.PersonasMujeresMayoresDe18.Count());
            Assert.AreEqual("Rosa Benitez", result.PersonasMujeresMayoresDe18.First());
        }

        [TestMethod]
        public void ProcessPersona_NullNameNullApellido_ReturnsErrors()
        {
            //Arrange
            var personaValidator = Substitute.For<IValidator>();
            var personaFormatter = Substitute.For<IPersonaFormatter>();
            var personaProcessor = new PersonasProcessor(personaValidator, personaFormatter);
            var personaRequest = new PersonaRequest
            {
                Personas = new List<Persona>
                {
                    new Persona
                    {
                        Edad = 19,
                        Sexo = Sexo.F
                    }
                }
            };
            var personasResult = new PersonasResult
            {
                ErrorMessages = new List<string>
                {
                    "El nombre es requerido.",
                    "El apellido es requerido."
                }
            };

            personaValidator.ValidateInputList(personaRequest).Returns(personasResult);

            //Act
            ProcessResult result = personaProcessor.Process(personaRequest);

            //Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("El proceso no puede ser completado. " +
                "Error: El nombre es requerido.\nEl apellido es requerido.",
                result.ErrorMessage);
        }

    }
}
