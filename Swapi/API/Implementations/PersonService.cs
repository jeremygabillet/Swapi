using System;
using System.Threading.Tasks;

namespace Swapi.API.Implementations
{
    public class PersonService : BaseApi, IPersonService
    {
        public Task<string> CallApi(int idPerson)
        {
            return CallBaseApi($"http://swapi.dev/api/people/{idPerson}/");
        }
    }
}
