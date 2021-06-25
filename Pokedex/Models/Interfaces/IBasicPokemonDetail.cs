namespace Pokedex.Models.Interfaces
{
    public interface IBasicPokemonDetail
    {
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool? IsLegendary { get; }
        string Information { get; }
        string Error { get; }
    }
}