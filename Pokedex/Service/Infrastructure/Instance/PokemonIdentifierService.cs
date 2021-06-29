using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Pokedex.Service.Common;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models.InternalModels.PokemonIdentity;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Infrastructure.Instance
{
    /// <summary>
    /// A class to use to get pokemon identity details from an external API call.
    /// </summary>
    /// <inheritdoc/>
    public class PokemonIdentifierService : IPokemonIdentifierService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _url;

        public PokemonIdentifierService(IHttpClientFactory clientFactory, string url = "https://pokeapi.co/api/v2/pokemon/")
        {
            _clientFactory = clientFactory;
            _url = string.IsNullOrWhiteSpace(url)
             ? ConfigurationHolder.Configuration.GetValue<string>("PokemonIdentityApi")
             : url.Trim();
        }

        public async Task<IPokemonIdentity> GetPokemonIdentity(string pokemonName)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync
                <PokemonIdentity>($"{_url}{pokemonName}");

            if (result != null)
                return new Models.ReturnedModels.Instances.PokemonIdentity(
                    result.Id, result?.Name, result.Height, result.Weight);

            throw new Exception(Constants.UnableToFindRequestedPokemonText);
        }
    }
}