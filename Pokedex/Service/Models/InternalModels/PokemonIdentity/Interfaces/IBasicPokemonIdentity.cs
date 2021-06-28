namespace Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces
{
    /// <summary>
    /// An interface to implement in [internal] models classes that will hold basic pokemon identity details<br/>
    /// that are returned from the service name space.
    /// </summary>
    public interface IBasicPokemonIdentity
    {
        int Id { get; }
        string Name { get; }
    }
}