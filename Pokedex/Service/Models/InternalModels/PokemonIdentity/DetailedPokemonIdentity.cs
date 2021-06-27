using Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces;

namespace Pokedex.Service.Models.InternalModels.PokemonIdentity
{
    public class DetailedPokemonIdentity : IMorePokemonIdentity
    {
        public int Id { get; }
        public string Name { get; }
        public int Weight { get; }
        public int Height { get; }

        public DetailedPokemonIdentity(int id, string name, int weight, int height)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Height = height;
        }
    }
}