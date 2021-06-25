using System.Threading.Tasks;
using Pokedex.Models.Interfaces;

namespace Pokedex.Application.Infrastructure.Interfaces
{
    public interface IPokemonProcessor
    {
        Task<IBasicPokemonDetail> GetBasicPokemonDetail(string pokemonName);

        Task<IMorePokemonDetail> GetPokemonDetail(string pokemonName);
    }
}