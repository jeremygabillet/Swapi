using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Swapi.API;
using Swapi.API.Implementations;
using Swapi.Entities;

namespace Swapi
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();
            AfficherInformations();
            Console.ReadLine();
        }

        public static void RegisterServices()
        {
            ServiceCollection.AddService<IPlanetService, PlanetService>();
            ServiceCollection.AddService<IPersonService, PersonService>();
            ServiceCollection.AddService<IFilmService, FilmService>();
        }

        public static async void AfficherInformations()
        {
            await AfficherInformationsPlanete(1);
            await AfficherInformationsPlanete(2);
            await AfficherInfoPersonne(1);
            await AfficherInfoPersonne(9);
            await AfficherInfoFilm(1);
            await AfficherInfoFilm(5);

            // afficher des informations sur les films, les personnes, les vaisseaux, les espèces, les véhicules etc...
        }

        public static async Task AfficherInformationsPlanete(int idPlanete) 
        {
            IPlanetService service = ServiceCollection.GetService<IPlanetService>();
            string json = await service.CallApi(idPlanete);
            Planet planete = JsonConvert.DeserializeObject<Planet>(json);

            Console.WriteLine(planete.Name + " : " + planete.Terrain);
        }

        public static async Task AfficherInfoPersonne(int idPersonne)
        {
            IPersonService service = ServiceCollection.GetService<IPersonService>();
            string json = await service.CallApi(idPersonne);
            Person person = JsonConvert.DeserializeObject<Person>(json);

            Console.WriteLine(person.Name + " : " + person.BirthYear);
        }
        public static async Task AfficherInfoFilm(int idFilm)
        {
            IFilmService service = ServiceCollection.GetService<IFilmService>();
            string json = await service.CallApi(idFilm);
            Film film = JsonConvert.DeserializeObject<Film>(json);

            Console.WriteLine(film.Title + " : " + film.ReleaseDate);
        }
    }
}
