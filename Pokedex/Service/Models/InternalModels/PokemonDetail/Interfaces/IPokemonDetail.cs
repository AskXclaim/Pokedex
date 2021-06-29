using System.Text.Json.Serialization;

namespace Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces
{
    /// <summary>
    /// An interface to implement in [internal] model classes that will hold pokemon details.
    /// </summary>
    public interface IPokemonDetail
    {
        int Id { get; }
        string Name { get; }
        Habitat Habitat { get; }
        FlavorTextEntries[] FlavorTextEntries { get; }
        bool IsLegendary { get; }
        Shape Shape { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
    }
}