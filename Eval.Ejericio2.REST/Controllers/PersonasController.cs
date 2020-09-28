using Eval.Ejercicio2.Business;
using Eval.Ejercicio2.Core.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eval.Ejericio2.REST.Controllers
{
    public class PersonasController : ApiController
    {
        public HttpResponseMessage Put([FromBody] IEnumerable<Persona> personas)
        {
            var validationProcess = new Validator();
            var personaFormatter = new PersonaFormatter();
            var personaProcessor = new PersonasProcessor(validationProcess, personaFormatter);

            var request = new PersonaRequest
            {
                Personas = (List<Persona>) personas
            };

            var result = personaProcessor.Process(request);

            if (result.Success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.PersonasMujeresMayoresDe18);
            }
            else
            {
                var error = new HttpError(result.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, error);
            }

        }
    }
}
