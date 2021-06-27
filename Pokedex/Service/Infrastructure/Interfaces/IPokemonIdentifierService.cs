using System.Threading.Tasks;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Infrastructure.Interfaces
{
    public interface IPokemonIdentifierService
    {
        Task<IBasicPokemonIdentity> GetBasicPokemonIdentity(string pokemonName);

        Task<IMorePokemonIdentity> GetDetailedPokemonIdentity(string pokemonName);
    }
}