namespace Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces
{
    public interface IMorePokemonIdentity : IBasicPokemonIdentity
    {
        int Weight { get; }
        int Height { get; }
    }
}