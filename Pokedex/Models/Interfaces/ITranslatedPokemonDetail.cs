namespace Pokedex.Models.Interfaces
{
    /// <summary>
    /// An interface to implement in [Controller] models classes that will hold<br/>
    /// pokemon details along with a fun translated description.
    /// </summary>
    public interface ITranslatedPokemonDetail : IPokemonDetail
    {
        public string Information { get; }
    }
}