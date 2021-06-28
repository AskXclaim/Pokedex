using Pokedex.Application.Models.Interfaces;

namespace Pokedex.Application.Models.Instances
{
    /// <summary>
    /// An [Application] model class to use to hold basic pokemon details.
    /// </summary>
    public class BasicPokemonModel : IBasicPokemonDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool? IsLegendary { get; }
        public bool HasError { get; }
        public string Error { get; }

        public BasicPokemonModel(string name, string description, string habitat,
            bool? isLegendary, bool hasError, string error = "")
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            HasError = hasError;
            Error = error;
        }
    }
}