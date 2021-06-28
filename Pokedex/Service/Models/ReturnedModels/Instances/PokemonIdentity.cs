using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Models.ReturnedModels.Instances
{
    /// <summary>
    /// A [Service] model class to use to hold pokemon details. This model is returned out.
    /// </summary>
    public class PokemonIdentity : IPokemonIdentity
    {
        public int Id { get; }
        public string Name { get; }
        public int Height { get; }
        public int Weight { get; }

        public PokemonIdentity(int id, string name, int height, int weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Height = height;
        }
    }
}