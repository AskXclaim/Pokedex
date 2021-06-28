using System.Threading.Tasks;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Infrastructure.Interfaces
{
    /// <summary>
    /// An interface to implement to be able to get Pokemon identity information.
    /// </summary>
    public interface IPokemonIdentifierService
    {
        /// <summary>
        /// An async method to use to get basic pokemon identity details.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns basic pokemon identity details</returns>
        Task<IBasicPokemonIdentity> GetBasicPokemonIdentity(string pokemonName);

        /// <summary>
        /// An async method to use to get detailed pokemon identity information.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns detailed pokemon information</returns>
        Task<IMorePokemonIdentity> GetDetailedPokemonIdentity(string pokemonName);
    }
}