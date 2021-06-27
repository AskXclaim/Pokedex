using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Models.ReturnedModels.Instances
{
    public class MorePokemonDetail : IMorePokemonDetail
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }
        public int Height { get; }
        public int Weight { get; }
        public bool IsBaby { get; }
        public bool IsMythical { get; }
        public string Shape { get; }
        public string Information { get; }

        public MorePokemonDetail(int id, string name, string description,
            string habitat, bool isLegendary, int height, int weight,
            bool isBaby, bool isMythical, string shape, string information)
        {
            Id = id;
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Height = height;
            Weight = weight;
            IsBaby = isBaby;
            IsMythical = isMythical;
            Shape = shape;
            Information = information;
        }
    }
}