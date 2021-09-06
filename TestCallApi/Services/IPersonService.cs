using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCallApi.Models;

namespace TestCallApi.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPersons();
        Task<Person> GetPerson(int id);
        Task<Person> CreatePerson(Person model);
        Task<Person> UpdatePerson(int id, Person model);
        Task<Person> DeletePerson(int id);
    }
}
