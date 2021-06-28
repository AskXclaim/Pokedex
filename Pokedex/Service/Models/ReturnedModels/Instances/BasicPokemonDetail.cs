using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Models.ReturnedModels.Instances
{
    /// <summary>
    /// A [Service] model class to use to hold basic pokemon details.<br/>
    /// This model is returned out.
    /// </summary>
    public class BasicPokemonDetail : IBasicPokemonDetail
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }

        public BasicPokemonDetail(int id, string name, string description,
        string habitat, bool isLegendary)
        {
            Id = id;
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }
    }
}