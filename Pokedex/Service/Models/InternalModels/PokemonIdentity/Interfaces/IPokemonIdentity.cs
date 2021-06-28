namespace Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces
{
    /// <summary>
    /// An interface to implement in [internal] model classes that will hold pokemon details.
    /// </summary>
    public interface IPokemonIdentity
    {
        int Id { get; }
        string Name { get; }
        int Weight { get; }
        int Height { get; }
    }
}