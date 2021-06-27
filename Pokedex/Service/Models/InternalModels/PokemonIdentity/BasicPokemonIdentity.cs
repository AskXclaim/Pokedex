using Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces;

namespace Pokedex.Service.Models.InternalModels.PokemonIdentity
{
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