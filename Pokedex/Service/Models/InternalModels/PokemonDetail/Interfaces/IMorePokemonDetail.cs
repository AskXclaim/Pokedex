namespace Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces
{
    /// <summary>
    /// An interface to implement in [internal] models classes that will hold detailed pokemon information.<br/>
    /// Please note, this is used only internally within the Service namespace.
    /// </summary>
    public interface IMorePokemonDetail : IBasicPokemonDetail
    {
        Shape Shape { get; }
        bool IsBaby { get; }
        bool IsMythical { get; }
    }
}