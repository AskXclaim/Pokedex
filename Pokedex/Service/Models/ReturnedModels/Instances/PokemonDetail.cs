using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Models.ReturnedModels.Instances
{
    /// <summary>
    /// A [Service] model class to use to hold pokemon details.This model is returned out.
    /// </summary>
    public class PokemonDetail : IPokemonDetail
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }
        public int Height { get; }
        public int Weight { get; }
        public string Shape { get; }
        public bool IsBaby { get; }
        public bool IsMythical { get; }
        public string Information { get; }

        public PokemonDetail(int id, string name, string description,
            string habitat, bool isLegendary, int height, int weight, string shape,
            bool isBaby, bool isMythical, string information)
        {
            Id = id;
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
            Shape = shape;
            IsBaby = isBaby;
            IsMythical = isMythical;
            Information = information;
        }
    }
}