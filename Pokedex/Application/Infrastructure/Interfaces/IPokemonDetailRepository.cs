using System.Threading.Tasks;
using Pokedex.Application.Models.Interfaces;

namespace Pokedex.Application.Infrastructure.Interfaces
{
    /// <summary>
    /// An interface to implement in to get Pokemon details.
    /// </summary>
    public interface IPokemonDetailRepository
    {
        /// <summary>
        /// An async method to use to get basic pokemon details.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns basic pokemon details</returns>
        Task<IBasicPokemonDetails> GetBasicPokemonDetails(string pokemonName);

        /// <summary>
        /// An async method to use to get details pokemon information, with the description <br/>
        /// being translated to the agreed translation.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns detailed pokemon information</returns>
        Task<IMorePokemonDetails> GetTranslatedPokemonDetails(string pokemonName);
    }
}