namespace Pokedex.Models.Interfaces
{
    /// <summary>
    /// An interface to implement in [Controller] models classes that will hold pokemon details.
    /// </summary>
    public interface IPokemonDetail
    {
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool IsLegendary { get; }
        int Height { get; }
        int Weight { get; }
        string Shape { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
    }
}