﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models.ReturnedModels.Instances;
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

        public PokemonIdentifierService(IHttpClientFactory clientFactory, IConfiguration config, string url = "https://pokeapi.co/api/v2/pokemon/")
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            config = config == null && string.IsNullOrWhiteSpace(url)
                ? throw new ArgumentNullException(nameof(config)) : config;
            _url = string.IsNullOrWhiteSpace(url) ? config.GetValue<string>("PokemonIdentityApi") : url.Trim();
        }

        public async Task<IBasicPokemonIdentity> GetBasicPokemonIdentity(string pokemonName)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync
                <Models.InternalModels.PokemonIdentity.BasicPokemonIdentity>($"{_url}{pokemonName}");

            if (result != null) return new BasicPokemonIdentity(result.Id, result?.Name);

            throw new Exception("Unable to find requested pokemon");
        }

        public async Task<IMorePokemonIdentity> GetDetailedPokemonIdentity(string pokemonName)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync
                <Models.InternalModels.PokemonIdentity.DetailedPokemonIdentity>($"{_url}{pokemonName}");

            if (result != null)
                return new DetailedPokemonIdentity(result.Id, result?.Name, result.Height, result.Weight);

            throw new Exception("Unable to find requested pokemon");
        }
    }
}