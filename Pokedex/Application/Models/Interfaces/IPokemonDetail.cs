namespace Pokedex.Application.Models.Interfaces
{
    /// <summary>
    /// An interface to implement in [Application] models classes that will hold pokemon details.
    /// </summary>
    public interface IPokemonDetail
    {
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool? IsLegendary { get; }
        int? Height { get; }
        int? Weight { get; }
        string Shape { get; }
        bool? IsBaby { get; }
        bool? IsMythical { get; }
        string Information { get; }
        bool HasError { get; }
        string Error { get; }
    }
}