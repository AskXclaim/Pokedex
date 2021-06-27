using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Models.ReturnedModels.Instances
{
    public class DetailedPokemonIdentity : IMorePokemonIdentity
    {
        public int Id { get; }
        public string Name { get; }
        public int Height { get; }
        public int Weight { get; }

        public DetailedPokemonIdentity(int id, string name, int height, int weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Height = height;
        }
    }
}