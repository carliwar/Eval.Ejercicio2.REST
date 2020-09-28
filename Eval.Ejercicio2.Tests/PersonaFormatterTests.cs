using Eval.Ejercicio2.Business;
using Eval.Ejercicio2.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eval.Ejercicio2.Tests
{
    [TestClass]
    public class PersonaFormatterTests
    {       

        [TestMethod]
        public void FormatPersona_PersonaNombreRosaApellidoBenitez_ReturnsRosaBenitez()
        {
            //Arrange
            var formatPersona = new PersonaFormatter();
            var persona = new Persona
            {
                Nombre = "Rosa",
                Apellido = "Benitez"
            };

            //Act
            string result = formatPersona.FormatPersona(persona);

            //Assert
            Assert.AreEqual("Rosa Benitez", result);
        }        
    }
}
