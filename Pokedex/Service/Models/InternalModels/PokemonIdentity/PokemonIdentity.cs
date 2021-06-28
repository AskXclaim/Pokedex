using Pokedex.Service.Models.InternalModels.PokemonIdentity.Interfaces;

namespace Pokedex.Service.Models.InternalModels.PokemonIdentity
{
    /// <summary>
    /// An [internal] [Service] model class to use to hold pokemon details.
    /// </summary>
    public class PokemonIdentity : IPokemonIdentity
    {
        public int Id { get; }
        public string Name { get; }
        public int Weight { get; }
        public int Height { get; }

        public PokemonIdentity(int id, string name, int weight, int height)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Height = height;
        }
    }
}