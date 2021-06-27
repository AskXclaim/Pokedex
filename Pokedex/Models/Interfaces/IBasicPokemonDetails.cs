namespace Pokedex.Models.Interfaces
{
    public interface IBasicPokemonDetails
    {
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool IsLegendary { get; }
    }
}