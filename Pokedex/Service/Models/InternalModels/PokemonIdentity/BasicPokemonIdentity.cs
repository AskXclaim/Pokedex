using Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces;

namespace Pokedex.Service.Models.InternalModels.PokemonIdentity
{
    /// <summary>
    /// A [Service] model class to use to hold basic pokemon details.<br/>
    /// This class is not returned out.
    /// </summary>
    public class BasicPokemonIdentity : IBasicPokemonIdentity
    {
        public int Id { get; }
        public string Name { get; }

        public BasicPokemonIdentity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}