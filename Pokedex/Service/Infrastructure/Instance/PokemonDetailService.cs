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
using Pokedex.Service.Models.ReturnedModels.Instances;
using Pokedex.Service.Models.ReturnedModels.Interfaces;
using MorePokemonDetail = Pokedex.Service.Models.InternalModels.PokemonDetail.MorePokemonDetail;

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
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _pokemonIdentifier = pokemonIdentifier;
            config = config ?? throw new ArgumentNullException(nameof(config));
            _translationSettings = config.GetSection("TranslationSettings").Get<TranslationSettings>();
            _url = string.IsNullOrWhiteSpace(url) ? config.GetValue<string>("PokemonDetailsApi") : url.Trim(); ;
        }

        public async Task<IBasicPokemonDetail> GetBasicPokemonDetails(string pokemonName)
        {
            var identifiedPokemon = await _pokemonIdentifier.GetBasicPokemonIdentity(pokemonName);

            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync
                <BasicPokemonDetails>($"{_url}{identifiedPokemon.Id}");

            if (result != null)
                return new BasicPokemonDetail(result.Id, result.Name,
                    GetFlavorText(result), result.Habitat?.Name, result.IsLegendary);

            throw GetException();
        }

        private string GetFlavorText(Models.InternalModels.PokemonDetail.Interfaces.IBasicPokemonDetail result)
        {
            var value = result.FlavorTextEntries.FirstOrDefault(
                fte => fte.Language.Name == _translationSettings.Language)?.FlavorText;
            return Regex.Replace(value ?? "", NewLine, " ");
        }

        public async Task<IMorePokemonDetail> GetTranslatedPokemonDetails(string pokemonName)
        {
            var identifiedPokemon = await _pokemonIdentifier.GetDetailedPokemonIdentity(pokemonName);

            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<MorePokemonDetail>($"{_url}/{identifiedPokemon.Id}");

            if (result == null) throw GetException();

            var description = GetFlavorText(result);
            var translation = await GetTranslation(description, result?.Habitat?.Name, result.IsLegendary);
            var information = translation.Equals(description, StringComparison.InvariantCultureIgnoreCase)
                ? Constants.DescriptionTranslatedUnsuccessfullyText : "";
            return GetTranslatedPokemonDetails(result, translation, identifiedPokemon, information);
        }

        private IMorePokemonDetail GetTranslatedPokemonDetails(MorePokemonDetail result,
            string translation, IMorePokemonIdentity identifiedPokemon, string information)
        {
            return new Models.ReturnedModels.Instances.MorePokemonDetail(result.Id, result.Name, translation, result?.Habitat.Name,
                result.IsLegendary, identifiedPokemon.Height, identifiedPokemon.Weight, result.Shape?.Name,
                result.IsBaby, result.IsMythical, information);
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