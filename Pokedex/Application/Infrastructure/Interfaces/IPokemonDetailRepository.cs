using System.Threading.Tasks;
using Pokedex.Application.Models.Interfaces;

namespace Pokedex.Application.Infrastructure.Interfaces
{
    public interface IPokemonDetailRepository
    {
        Task<IBasicPokemonDetails> GetBasicPokemonDetails(string pokemonName);

        Task<IMorePokemonDetails> GetTranslatedPokemonDetails(string pokemonName);
    }
}