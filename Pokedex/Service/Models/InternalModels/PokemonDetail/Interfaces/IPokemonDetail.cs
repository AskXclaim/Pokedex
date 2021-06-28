namespace Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces
{
    /// <summary>
    /// An interface to implement in [internal] model classes that will hold pokemon details.
    /// </summary>
    public interface IPokemonDetail
    {
        int Id { get; }
        string Name { get; }
        FlavorTextEntries[] FlavorTextEntries { get; }
        Habitat Habitat { get; }
        public bool IsLegendary { get; }
        Shape Shape { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
    }
}