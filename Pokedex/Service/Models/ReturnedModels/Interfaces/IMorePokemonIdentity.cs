namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    /// <summary>
    /// An interface to implement in models classes that will hold detailed pokemon identity information<br/>
    /// that are returned from the service name space.
    /// </summary>
    public interface IMorePokemonIdentity : IBasicPokemonIdentity
    {
        int Height { get; }
        int Weight { get; }
    }
}