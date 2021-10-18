using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.API.Implementations
{
    class FilmService : BaseApi, IFilmService
    {
        public Task<string> CallApi(int idFilm)
        {
            return CallBaseApi($"http://swapi.dev/api/films/{idFilm}/");
        }
    }
}
