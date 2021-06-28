using System.Threading.Tasks;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Infrastructure.Interfaces
{
    /// <summary>
    /// An interface to implement to be able to get Pokemon details.
    /// </summary>
    public interface IPokemonDetailService
    {
        /// <summary>
        /// An async method to use to get pokemon details.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        Task<IPokemonDetail> GetBasicPokemonDetails(string pokemonName);

        /// <summary>
        /// An async method to use to get pokemon details along with a fun translation.
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        Task<IPokemonDetail> GetTranslatedPokemonDetails(string pokemonName);
    }
}