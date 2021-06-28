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
        /// An async method to use to get a pokemon's identity information.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>Returns detailed pokemon information</returns>
        Task<IPokemonIdentity> GetPokemonIdentity(string pokemonName);
    }
}