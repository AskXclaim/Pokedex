using Pokedex.Models.Interfaces;

namespace Pokedex.Models
{
    public class PokemonModel : IBasicPokemonDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool? IsLegendary { get; }
        public string Information { get; }
        public string Error { get; }

        public PokemonModel(string name, string description, string habitat,
            bool? isLegendary, string information, string error = null)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Information = information;
            Error = error;
        }
    }
}