using Pokedex.Application.Models.Interfaces;

namespace Pokedex.Application.Models.Instances
{
    public class DetailedPokemonModel : IMorePokemonDetails
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool? IsLegendary { get; }
        public int? Height { get; }
        public int? Weight { get; }
        public string Information { get; }
        public bool HasError { get; }
        public string Error { get; }

        public DetailedPokemonModel(string name, string description,
        string habitat, bool? isLegendary, int? height, int? weight,
        string information, bool hasError, string error = "")
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
            Information = information;
            HasError = hasError;
            Error = error;
        }
    }
}