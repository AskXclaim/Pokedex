namespace Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces
{
    /// <summary>
    /// An interface to implement in [internal] models classes that will hold detailed pokemon information<br/>
    /// that are returned from the service name space.
    /// </summary>
    public interface IMorePokemonIdentity : IBasicPokemonIdentity
    {
        int Weight { get; }
        int Height { get; }
    }
}