using System.Threading.Tasks;

namespace Swapi.API.Implementations
{
    public class PlanetService : BaseApi, IPlanetService
    {
        public Task<string> CallApi(int idPlanete)
        {
            return CallBaseApi($"http://swapi.dev/api/planets/{idPlanete}/");
        }
    }
}
