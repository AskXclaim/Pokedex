using Pokedex.Models.Interfaces;

namespace Pokedex.Models
{
    public class PokemonModel : IBasicDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }

        public PokemonModel(string name, string description, string habitat, bool isLegendary)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }
    }
}