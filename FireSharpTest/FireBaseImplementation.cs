using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FireSharpTest
{
    public class FireBaseImplementation
    {
        IFirebaseConfig config;

        IFirebaseClient client;

        public FireBaseImplementation(string authSecret, string basePath)
        {
            config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };

            client = new FirebaseClient(config);

        }

        public string Insert()
        {
            try
            {

                dynamic person = new System.Dynamic.ExpandoObject();

                person.Nombre = "Luis";
                person.Apellido = "Orostizaga";
                person.Edad = 28;
                person.Email = "luis.orostizaga@gmail.com";
                person.Number = 99;

                var setter = client.Set("PersonList/" + person.Number, person);
                return "Datos insertados correctamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }


        }

        public dynamic GetPerson(string numero)
        {
            var result = client.Get("PersonList/" + numero);

            dynamic person = result.ResultAs<dynamic>();

            return person;

        }

        public string Update(string numero)
        {
            try
            {

                dynamic person = new System.Dynamic.ExpandoObject();

                person.Nombre = "Kido";
                person.Apellido = "Orostizaga";
                person.Edad = 28;
                person.Email = "kido@gmail.com";

                var setter = client.Update("PersonList/" + numero, person);

                return "Datos actualizados correctamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }

        public string Delete(string numero)
        {
            try
            {
                var result = client.Delete("PersonList/" + numero);

                return "Datos eliminados correctamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }

        public List<dynamic> GetAllPersons()
        {
            FirebaseResponse resp = client.Get("PersonList/");

            JObject json = (JObject)JsonConvert.DeserializeObject(resp.Body);

            var list = new List<dynamic>();


            foreach (var s in json)
            {
                if (s.Value.ToString() != "")
                {
                    list.Add(JsonConvert.DeserializeObject<dynamic>(s.Value.ToString()));
                }
            }

            return list;

        }

    }
}
