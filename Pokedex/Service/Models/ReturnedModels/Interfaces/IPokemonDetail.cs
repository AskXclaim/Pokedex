namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    /// <summary>
    /// An interface to implement in returned model classes that will hold pokemon details.
    /// </summary>
    public interface IPokemonDetail
    {
        int Id { get; }
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool IsLegendary { get; }
        int Height { get; }
        int Weight { get; }
        string Shape { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
        string Information { get; }
    }
}