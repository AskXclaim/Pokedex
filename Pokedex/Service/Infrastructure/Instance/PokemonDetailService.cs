using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Pokedex.Service.Common;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models.InternalModels.PokemonDetail;
using Pokedex.Service.Models.InternalModels.Translations;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Infrastructure.Instance
{
    /// <summary>
    /// A class to use to get Pokemon details.
    /// </summary>
    /// <inheritdoc/>
    public class PokemonDetailService : IPokemonDetailService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IPokemonIdentifierService _pokemonIdentifier;
        private readonly string _url;
        private readonly TranslationSettings _translationSettings;
        private const string NewLine = @"\t|\n|\r|\f";

        public PokemonDetailService(IHttpClientFactory clientFactory, IPokemonIdentifierService pokemonIdentifier,
        IConfiguration config, string url = "https://pokeapi.co/api/v2/pokemon-species/")
        {
            _clientFactory = clientFactory;
            _pokemonIdentifier = pokemonIdentifier;
            _translationSettings = config.GetSection("TranslationSettings").Get<TranslationSettings>();
            _url = string.IsNullOrWhiteSpace(url) ? config.GetValue<string>("PokemonDetailsApi") : url.Trim();
        }

        public async Task<IPokemonDetail> GetBasicPokemonDetails(string pokemonName)
        {
            var identifiedPokemon = await _pokemonIdentifier.GetPokemonIdentity(pokemonName);

            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<PokemonDetail>($"{_url}{identifiedPokemon.Id}");

            if (result != null) return GetPokemonDetails(
                result, identifiedPokemon, GetFlavorText(result), string.Empty);

            throw GetException();
        }

        private IPokemonDetail GetPokemonDetails(
        Models.InternalModels.PokemonDetail.Interfaces.IPokemonDetail result,
        IPokemonIdentity identifiedPokemon, string description, string information)
        {
            return new Models.ReturnedModels.Instances.PokemonDetail(
                result.Id, result.Name, description, result.Habitat?.Name, result.IsLegendary,
                identifiedPokemon.Height, identifiedPokemon.Weight, result.Shape.Name, result.IsBaby,
                result.IsMythical, information);
        }

        private string GetFlavorText(Models.InternalModels.PokemonDetail.Interfaces.IPokemonDetail result)
        {
            var value = result.FlavorTextEntries.FirstOrDefault(
                fte => fte.Language.Name == _translationSettings.Language)?.FlavorText;
            return Regex.Replace(value ?? "", NewLine, " ");
        }

        public async Task<IPokemonDetail> GetTranslatedPokemonDetails(string pokemonName)
        {
            var identifiedPokemon = await _pokemonIdentifier.GetPokemonIdentity(pokemonName);

            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<PokemonDetail>($"{_url}/{identifiedPokemon.Id}");

            if (result == null) throw GetException();

            var description = GetFlavorText(result);
            var translation = await GetTranslation(description, result?.Habitat?.Name, result.IsLegendary);
            var information = translation.Equals(description, StringComparison.InvariantCultureIgnoreCase)
                ? Constants.DescriptionTranslatedUnsuccessfullyText : "";
            return GetPokemonDetails(result, identifiedPokemon, translation, information);
        }

        private Exception GetException() => new Exception(Constants.UnableToGetPokemonDetailsText);

        private async Task<string> GetTranslation(string description, string habitat, bool isLegendary)
        {
            var client = _clientFactory.CreateClient();
            try
            {
                var url =
                    _translationSettings.Habitat.Equals(habitat, StringComparison.CurrentCultureIgnoreCase)
                    || isLegendary ? _translationSettings.TranslationApiOption1 : _translationSettings.TranslationApiOption2;

                var response = await client.GetFromJsonAsync<Translation>($"{url}{description}");
                return response?.Contents?.Translated;
            }
            catch (Exception)
            {
                return description;
            }
        }
    }
}