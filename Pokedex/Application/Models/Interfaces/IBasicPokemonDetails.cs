namespace Pokedex.Application.Models.Interfaces
{
    /// <summary>
    /// An interface to implement in [Application] models classes that will hold basic pokemon details.
    /// </summary>
    public interface IBasicPokemonDetails
    {
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool? IsLegendary { get; }
        bool HasError { get; }
        string Error { get; }
    }
}