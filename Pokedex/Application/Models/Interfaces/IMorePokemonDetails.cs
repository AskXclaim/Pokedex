namespace Pokedex.Application.Models.Interfaces
{
    /// <summary>
    /// An interface to implement in models classes that will hold detailed pokemon information.
    /// </summary>
    public interface IMorePokemonDetails : IBasicPokemonDetails
    {
        int? Height { get; }
        int? Weight { get; }
        string Information { get; }
    }
}