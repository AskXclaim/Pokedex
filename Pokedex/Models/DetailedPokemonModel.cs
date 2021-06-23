using Pokedex.Models.Interfaces;

namespace Pokedex.Models
{
    public class DetailedPokemonModel : IMoreDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }
        public int Height { get; }
        public int Weight { get; }

        public DetailedPokemonModel(string name, string description,
        string habitat, bool isLegendary, int height, int weight)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
        }
    }
}