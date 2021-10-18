using System.Threading.Tasks;

namespace Swapi.API
{
    interface IApiService
    {
        Task<string> CallApi(int id);
    }
}
