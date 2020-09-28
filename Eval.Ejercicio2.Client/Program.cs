using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eval.Ejercicio2.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // EJEMPLO 1
            //PutPersonas(new List<PersonaRequestModel>());

            // EJEMPLO 2
            //var personas = new List<PersonaRequestModel>();
            //personas.Add(new PersonaRequestModel
            //{
            //    Nombre = "Karina",
            //    Apellido = "Navarrete",
            //    Edad = 27,
            //    Sexo = "F"
            //});
            //PutPersonas(personas);

            //EJEMPLO 3
            //var personas = new List<PersonaRequestModel>();
            //personas.Add(new PersonaRequestModel
            //{
            //    Nombre = "Karina",
            //    Apellido = "Navarrete",
            //    Edad = 27,
            //    Sexo = "F"
            //});
            //personas.Add(new PersonaRequestModel
            //{
            //    Nombre = "Carlos",
            //    Apellido = "Totoy",
            //    Edad = 29,
            //    Sexo = "M"
            //});

            //PutPersonas(personas);

            //EJEMPLO 4
            //var personas = new List<PersonaRequestModel>();
            //personas.Add(new PersonaRequestModel
            //{
            //    Nombre = "Karina",
            //    Apellido = "Navarrete",
            //    Edad = 27,
            //    Sexo = "F"
            //});
            //personas.Add(new PersonaRequestModel
            //{
            //    Nombre = "Monica",
            //    Apellido = "Molina",
            //    Edad = 55,
            //    Sexo = "F"
            //});

            //PutPersonas(personas);

            // EJEMPLO 5
            var personas = new List<PersonaRequestModel>();
            personas.Add(new PersonaRequestModel
            {
                Nombre = "Karina",
                Sexo = "F"
            });
            PutPersonas(personas);

        }

        private static void PutPersonas(List<PersonaRequestModel> personas)
        {
            var client = new RestClient("http://localhost:60694/api/");
            var request = new RestRequest("Personas", Method.PUT);
            var jsonSerializer = new RestSharp.Serialization.Json.JsonSerializer();

            var serializedList = jsonSerializer.Serialize(personas);

            request.AddParameter("text/json", serializedList, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var responseObject = JsonConvert.DeserializeObject<Error>(response.Content);
                Console.WriteLine(responseObject.Message);
                Console.ReadLine();
            }
            else
            {
                var responseObject = JsonConvert.DeserializeObject<List<string>>(response.Content);
                if(responseObject != null || responseObject.Count() > 0)
                {
                    Console.WriteLine("Las personas Mujeres mayores a 18 años son: ");

                    foreach (var personaResult in responseObject)
                    {
                        Console.WriteLine(personaResult);
                    }
                }
                else
                {
                    Console.WriteLine("No hubo personas Mujeres mayores a 18 años. ");
                }
                
            }           
            
            Console.ReadLine();
        }
    }
}
