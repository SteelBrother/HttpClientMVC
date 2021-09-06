using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestCallApi.Models;

namespace TestCallApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _person;
        public PersonService(HttpClient client)
        {
            _person = client;
        }
        public async Task<Person> CreatePerson(Person model)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _person.PostAsync($"https://localhost:44362/api/Persona", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Person>(result);
            }
            else
            {
                throw new Exception("Algo mal ha sucedido. Por favor intente mas tarde.");
            }
        }

        public async Task<Person> DeletePerson(int id)
        {
            var response = await _person.DeleteAsync($"https://localhost:44362/api/Persona/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Person>(result);
            }
            else
            {
                throw new Exception("Algo mal ha sucedido. Por favor intente mas tarde.");
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            var response = await _person.GetAsync($"https://localhost:44362/api/Persona/{id}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Person>(result);
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            var response = await _person.GetAsync("https://localhost:44362/api/Persona");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Person>>(result);
        }

        public async Task<Person> UpdatePerson(int id, Person model)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _person.PutAsync($"https://localhost:44362/api/Persona/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Person>(result);
            }
            else
            {
                throw new Exception("Algo mal ha sucedido. Por favor intente mas tarde.");
            }
        }
    }
}
