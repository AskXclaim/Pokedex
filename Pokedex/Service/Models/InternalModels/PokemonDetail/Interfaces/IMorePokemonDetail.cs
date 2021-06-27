namespace Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces
{
    public interface IMorePokemonDetail : IBasicPokemonDetail
    {
        bool IsBaby { get; }
        bool IsMythical { get; }
        Shape Shape { get; }
    }
}