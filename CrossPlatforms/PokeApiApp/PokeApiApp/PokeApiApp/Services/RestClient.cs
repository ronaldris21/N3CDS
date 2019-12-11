
namespace PokeApiApp.Services
{
    using PokeApiApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class RestClient : IDisposable
    {
        string url = "https://pokeapi.co/api/v2/pokemon?offset=0&limit=";
        HttpClient client;

        public void Dispose()
        {
            client.Dispose();
        }


        public async Task<Pokemondetail> PokemondetailMethod(string url)
        {
                var poke = new Pokemondetail();
                client = new HttpClient();
                var content = await client.GetAsync(url);
                var json = await content.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemondetail>(json);
        }


        public async Task<Pokemons> GetPokemons(int cantidad)
        {
            try
            {
                client = new HttpClient();
                var response = await client.GetAsync(url + cantidad);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemons>(jsonString);
                }
            }
            catch (Exception)
            {
                return default(Pokemons);
            }
            return default(Pokemons);
        }
    }
}
