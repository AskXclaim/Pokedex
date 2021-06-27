namespace Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces
{
    public interface IBasicPokemonDetail
    {
        int Id { get; }
        string Name { get; }
        FlavorTextEntries[] FlavorTextEntries { get; }
        Habitat Habitat { get; }
        public bool IsLegendary { get; }
    }
}