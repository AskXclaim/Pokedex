using Pokedex.Service.Common;

namespace Pokedex.Service.Models.ReturnedModels.Interfaces
{
    /// <summary>
    /// An interface to implement in models classes that will hold basic pokemon details<br/>
    /// that are returned from the service name space.
    /// </summary>
    public interface IBasicPokemonDetail
    {
        int Id { get; }
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool IsLegendary { get; }
    }
}