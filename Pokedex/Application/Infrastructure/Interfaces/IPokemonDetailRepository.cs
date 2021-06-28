using System.Threading.Tasks;
using Pokedex.Application.Models.Interfaces;

namespace Pokedex.Application.Infrastructure.Interfaces
{
    /// <summary>
    /// An interface to implement to be able to get Pokemon details.
    /// </summary>
    public interface IPokemonDetailRepository
    {
        /// <summary>
        /// An async method to use to get basic pokemon details.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns pokemon details</returns>
        Task<IPokemonDetail> GetBasicPokemonDetails(string pokemonName);

        /// <summary>
        /// An async method to use to get details pokemon information, with the description <br/>
        /// being translated to the agreed translation.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        Task<IPokemonDetail> GetTranslatedPokemonDetails(string pokemonName);
    }
}