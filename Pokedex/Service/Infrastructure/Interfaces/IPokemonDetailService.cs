using System.Threading.Tasks;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Infrastructure.Interfaces
{
    /// <summary>
    /// An interface to implement to be able to get Pokemon details/information.
    /// </summary>
    public interface IPokemonDetailService
    {
        /// <summary>
        /// An async method to use to get basic pokemon details.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns basic pokemon details</returns>
        Task<IBasicPokemonDetail> GetBasicPokemonDetails(string pokemonName);

        /// <summary>
        /// An async method to use to get detailed pokemon information.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns detailed pokemon information</returns>
        Task<IMorePokemonDetail> GetTranslatedPokemonDetails(string pokemonName);
    }
}