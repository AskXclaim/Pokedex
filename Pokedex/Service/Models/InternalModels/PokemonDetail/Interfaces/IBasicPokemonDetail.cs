namespace Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces
{
    /// <summary>
    /// An interface to implement in [internal] models classes that will hold basic pokemon details.<br/>
    /// Please note, this is used only internally within the Service namespace.
    /// </summary>
    public interface IBasicPokemonDetail
    {
        int Id { get; }
        string Name { get; }
        FlavorTextEntries[] FlavorTextEntries { get; }
        Habitat Habitat { get; }
        public bool IsLegendary { get; }
    }
}