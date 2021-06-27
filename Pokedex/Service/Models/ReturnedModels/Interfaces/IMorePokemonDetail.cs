namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    public interface IMorePokemonDetail : IBasicPokemonDetail
    {
        int Height { get; }
        int Weight { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
        string Information { get; }
    }
}