namespace Pokedex.Service.Models.Interfaces
{
    public interface IPokemonDetail
    {
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool IsLegendary { get; }
    }
}