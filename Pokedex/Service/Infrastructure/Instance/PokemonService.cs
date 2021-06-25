using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models;
using Pokedex.Service.Models.Interfaces;

namespace Pokedex.Service.Infrastructure.Instance
{
    public partial class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PokemonService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<PokemonIdentifier> IdentifyPokemon(string name)
        {
            var url = "https://pokeapi.co/api/v2/pokemon/";
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}{name}");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return null;
            var result = await response.Content.ReadFromJsonAsync<PokemonIdentifier>();
            if (result != null && result.Id > 0)
            {
                return result;
            }

            return null;
        }

        public async Task<IPokemonDetail> GetPokemonDetail(int id)
        {
            var url = "https://pokeapi.co/api/v2/pokemon-species/";
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}{id}");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return null;
            var result = await response.Content.ReadFromJsonAsync<PokemonDetail>();
            if (result != null && result.Id > 0)
            {
                return new Models.Instances.PokemonDetail(result.Name, await GetTranslation(
                        result.FlavorTextEntries?.Where(f => f.Language.Name == "en")?.FirstOrDefault()?.FlavorText),
                    result.Habitat.Name, result.IsLegendary);
            }

            return null;
        }

        private async Task<string> GetTranslation(string text, bool detailedTranslation = false)
        {
            var url = detailedTranslation ? "https://api.funtranslations.com:443/translate/yoda.json?text=" : "https://api.funtranslations.com:443/translate/shakespeare.json?text=";

            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}{HttpUtility.HtmlEncode(text)}");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return text;
            var result = await response.Content.ReadFromJsonAsync<ShakespeareTranslation>();
            if (result != null && !string.IsNullOrWhiteSpace(result.Contents?.Translated))
            {
                return result.Contents.Translated;
            }

            return text;
        }
    }
}