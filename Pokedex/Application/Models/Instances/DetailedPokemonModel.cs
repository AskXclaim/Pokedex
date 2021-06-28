using Pokedex.Application.Models.Interfaces;

namespace Pokedex.Application.Models.Instances
{
    /// <summary>
    /// An [Application] model class to use to hold detailed pokemon information.
    /// </summary>
    public class DetailedPokemonModel : IMorePokemonDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool? IsLegendary { get; }
        public int? Height { get; }
        public int? Weight { get; }
        public string Shape { get; }
        public bool? IsBaby { get; }
        public bool? IsMythical { get; }
        public string Information { get; }
        public bool HasError { get; }
        public string Error { get; }

        public DetailedPokemonModel(string name, string description,
        string habitat, bool? isLegendary, int? height, int? weight,
        string shape, bool? isBaby, bool? isMythical, string information,
        bool hasError, string error = "")
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
            Information = information;
            HasError = hasError;
            Shape = shape;
            IsBaby = isBaby;
            IsMythical = isMythical;
            Error = error;
        }
    }
}