using Pokedex.Models.Interfaces;

namespace Pokedex.Models.Instances
{
    public class DetailedPokemonModel : IMorePokemonDetails
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }
        public int? Height { get; }
        public int? Weight { get; }
        public string Information { get; }

        public DetailedPokemonModel(string name, string description,
        string habitat, bool isLegendary, int? height, int? weight, string information)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
            Information = information;
        }
    }
}