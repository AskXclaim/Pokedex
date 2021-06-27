using System.Threading.Tasks;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Infrastructure.Interfaces
{
    public interface IPokemonDetailService
    {
        Task<IBasicPokemonDetail> GetBasicPokemonDetails(string pokemonName);

        Task<IMorePokemonDetail> GetTranslatedPokemonDetails(string pokemonName);
    }
}