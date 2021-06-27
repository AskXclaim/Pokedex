namespace Pokedex.Application.Models.Interfaces
{
    public interface IMorePokemonDetails : IBasicPokemonDetails
    {
        int? Height { get; }
        int? Weight { get; }
        string Information { get; }
    }
}