using Pokedex.Models.Interfaces;

namespace Pokedex.Models.Instances
{
    /// <summary>
    /// An [Controller] model class to use to hold pokemon details.
    /// </summary>
    public class PokemonModel : IPokemonDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }
        public int Height { get; }
        public int Weight { get; }
        public string Shape { get; }
        public bool IsBaby { get; }
        public bool IsMythical { get; }

        public PokemonModel(string name, string description, string habitat,
        bool isLegendary, int height, int weight, string shape, bool isBaby, bool isMythical)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
            Shape = shape;
            IsBaby = isBaby;
            IsMythical = isMythical;
        }
    }
}