using Pokedex.Service.Common;

namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    public interface IBasicPokemonIdentity
    {
        int Id { get; }
        string Name { get; }
    }
}