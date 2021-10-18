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
        }

        public static async void AfficherInformations()
        {
            await AfficherInformationsPlanete(1);
            await AfficherInformationsPlanete(2);

            // afficher des informations sur les films, les personnes, les vaisseaux, les espèces, les véhicules etc...
        }

        public static async Task AfficherInformationsPlanete(int idPlanete) 
        {
            IPlanetService service = ServiceCollection.GetService<IPlanetService>();
            string json = await service.CallApi(idPlanete);
            Planet planete = JsonConvert.DeserializeObject<Planet>(json);

            Console.WriteLine(planete.Name + " : " + planete.Terrain);
        }
    }
}
