namespace Pokedex.Models.Interfaces
{
    /// <summary>
    /// An interface to implement in [Controller] models classes that will hold detailed pokemon information.
    /// </summary>
    public interface IMorePokemonDetails : IBasicPokemonDetails
    {
        int Height { get; }
        int Weight { get; }
        string Shape { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
        public string Information { get; }
    }
}