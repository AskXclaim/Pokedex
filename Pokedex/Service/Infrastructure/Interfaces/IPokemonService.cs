using System.Threading.Tasks;
using Pokedex.Service.Models;
using Pokedex.Service.Models.Interfaces;

namespace Pokedex.Service.Infrastructure.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonIdentifier> IdentifyPokemon(string name);

        Task<IPokemonDetail> GetPokemonDetail(int id);
    }
}