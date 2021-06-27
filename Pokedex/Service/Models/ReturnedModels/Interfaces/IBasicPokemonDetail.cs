using Pokedex.Service.Common;

namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    public interface IBasicPokemonDetail
    {
        int Id { get; }
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool IsLegendary { get; }
    }
}