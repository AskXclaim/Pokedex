namespace Pokedex.Application.Models.Interfaces
{
    /// <summary>
    /// An interface to implement in [Application] models classes that will hold detailed pokemon information.
    /// </summary>
    public interface IMorePokemonDetail : IBasicPokemonDetail
    {
        int? Height { get; }
        int? Weight { get; }
        string Shape { get; }
        bool? IsBaby { get; }
        bool? IsMythical { get; }
        string Information { get; }
    }
}