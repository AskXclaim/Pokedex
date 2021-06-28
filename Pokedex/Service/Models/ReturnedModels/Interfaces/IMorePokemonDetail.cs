namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    /// <summary>
    /// An interface to implement in models classes that will hold detailed pokemon information<br/>
    /// that are returned from the service namespace.
    /// </summary>
    public interface IMorePokemonDetail : IBasicPokemonDetail
    {
        int Height { get; }
        int Weight { get; }
        string Shape { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
        string Information { get; }
    }
}