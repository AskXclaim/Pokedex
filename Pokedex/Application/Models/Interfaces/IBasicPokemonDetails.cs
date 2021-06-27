namespace Pokedex.Application.Models.Interfaces
{
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