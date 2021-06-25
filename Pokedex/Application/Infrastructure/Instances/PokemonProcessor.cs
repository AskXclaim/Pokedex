using System;
using System.Threading.Tasks;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Models;
using Pokedex.Models.Interfaces;
using Pokedex.Service.Infrastructure.Interfaces;

namespace Pokedex.Application.Infrastructure.Instances
{
    public class PokemonProcessor : IPokemonProcessor
    {
        private readonly IPokemonService _service;
        private const string Empty = "";

        public PokemonProcessor(IPokemonService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IBasicPokemonDetail> GetBasicPokemonDetail(string pokemonName)
        {
            try
            {
                var result = await _service.IdentifyPokemon(pokemonName);

                if (result == null || result.Id <= 0) return new PokemonModel(Empty, Empty, Empty, null,
                    $"Pokemon with name {pokemonName} does not appear to exist");

                var finalResult = await _service.GetPokemonDetail(result.Id);
                return new PokemonModel(finalResult.Name, finalResult.Description,
                    finalResult.Habitat, finalResult.IsLegendary, Empty);
            }
            catch (Exception ex)
            {
                return new PokemonModel(Empty, Empty, Empty, null, Empty, FormatError(ex, pokemonName));
            }
        }

        public async Task<IMorePokemonDetail> GetPokemonDetail(string pokemonName)
        {
            try
            {
                var result = await _service.IdentifyPokemon(pokemonName);

                if (result == null || result.Id <= 0) return new DetailedPokemonModel
                    (Empty, Empty, Empty, null, null, null,
                    $"Pokemon with name {pokemonName} does not appear to exist");

                var finalResult = await _service.GetPokemonDetail(result.Id);

                return new DetailedPokemonModel(finalResult.Name, finalResult.Description,
                    finalResult.Habitat, finalResult.IsLegendary, 3, 30, Empty);
            }
            catch (Exception ex)
            {
                return new DetailedPokemonModel
                (Empty, Empty, Empty, null, null, null, Empty, FormatError(ex, pokemonName));
            }
        }

        private string FormatError(Exception ex, string pokemonName) =>
            $"{pokemonName} pokemon details were not gotten as a result of " +
            $"the following exception:'{ex.Message}'." +
            $"{Environment.NewLine}If this continues please contact your administrator";
    }
}