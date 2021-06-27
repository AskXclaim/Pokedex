namespace Pokedex.Models.Interfaces
{
    public interface IMorePokemonDetails : IBasicPokemonDetails
    {
        int? Height { get; }
        int? Weight { get; }
        public string Information { get; }
    }
}