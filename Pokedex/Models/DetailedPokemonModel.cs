using Pokedex.Models.Interfaces;

namespace Pokedex.Models
{
    public class DetailedPokemonModel : IMorePokemonDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool? IsLegendary { get; }
        public int? Height { get; }
        public int? Weight { get; }
        public string Information { get; }
        public string Error { get; }

        public DetailedPokemonModel(string name, string description,
        string habitat, bool? isLegendary, int? height, int? weight,
        string information, string error = null)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
            Information = information;
            Error = error;
        }
    }
}