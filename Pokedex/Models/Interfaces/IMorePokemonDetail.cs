namespace Pokedex.Models.Interfaces
{
    public interface IMorePokemonDetail : IBasicPokemonDetail
    {
        int? Height { get; }
        int? Weight { get; }
    }
}