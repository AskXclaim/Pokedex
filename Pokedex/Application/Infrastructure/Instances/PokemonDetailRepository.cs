using System;
using System.Threading.Tasks;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Application.Models.Instances;
using Pokedex.Application.Models.Interfaces;
using Pokedex.Service.Infrastructure.Interfaces;

namespace Pokedex.Application.Infrastructure.Instances
{
    /// <summary>
    /// A Repository class to use to get pokemon details.
    /// </summary>
    /// <inheritdoc/>
    public class PokemonDetailRepository : IPokemonDetailRepository
    {
        private readonly IPokemonDetailService _detailService;
        private const string Empty = "";

        public PokemonDetailRepository(IPokemonDetailService detailService)
        {
            _detailService = detailService ?? throw new ArgumentNullException(nameof(detailService));
        }

        public async Task<IPokemonDetail> GetBasicPokemonDetails(string pokemonName)
        {
            try
            {
                var response = await _detailService.GetBasicPokemonDetails(pokemonName);

                return GetDetailedPokemonModel(response);
            }
            catch (Exception ex)
            {
                return GetDetailedPokemonModel(FormatError(ex, pokemonName));
            }
        }

        public async Task<IPokemonDetail> GetTranslatedPokemonDetails(string pokemonName)
        {
            try
            {
                var response = await _detailService.GetTranslatedPokemonDetails(pokemonName);

                return GetDetailedPokemonModel(response);
            }
            catch (Exception ex)
            {
                return GetDetailedPokemonModel(FormatError(ex, pokemonName));
            }
        }

        private IPokemonDetail GetDetailedPokemonModel(string error) =>
        new PokemonModel(Empty, Empty, Empty, null, null, null, Empty, null, null, Empty, true, error);

        private IPokemonDetail GetDetailedPokemonModel(Service.Models.ReturnedModels.Interfaces.IPokemonDetail response) =>
        new PokemonModel(response.Name, response.Description, response.Habitat, response.IsLegendary,
        response.Height, response.Weight, response.Shape, response.IsBaby, response.IsMythical,
        response.Information, false);

        private string FormatError(Exception ex, string pokemonName) =>
           (string.Format(Constants.ExceptionText, pokemonName, ex.Message, Environment.NewLine));
    }
}