namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    /// <summary>
    /// An interface to implement in returned model classes that will hold pokemon identity information.
    /// </summary>
    public interface IPokemonIdentity
    {
        int Id { get; }
        string Name { get; }
        int Height { get; }
        int Weight { get; }
    }
}