using Pokedex.Models.Interfaces;

namespace Pokedex.Models.Instances
{
    public class BasicPokemonModel : IBasicPokemonDetails
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }

        public BasicPokemonModel(string name, string description, string habitat,
            bool isLegendary)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }
    }
}