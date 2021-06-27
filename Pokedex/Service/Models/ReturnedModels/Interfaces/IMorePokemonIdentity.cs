namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    public interface IMorePokemonIdentity : IBasicPokemonIdentity
    {
        int Height { get; }
        int Weight { get; }
    }
}