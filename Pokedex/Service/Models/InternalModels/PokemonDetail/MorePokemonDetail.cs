using System.Text.Json.Serialization;
using Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces;

namespace Pokedex.Service.Models.InternalModels.PokemonDetail
{
    public class MorePokemonDetail : IMorePokemonDetail
    {
        public int Id { get; }
        public string Name { get; }

        [JsonPropertyName("flavor_text_entries")]
        public FlavorTextEntries[] FlavorTextEntries { get; }

        public Habitat Habitat { get; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; }

        [JsonPropertyName("is_Baby")]
        public bool IsBaby { get; }

        [JsonPropertyName("is_Mythical")]
        public bool IsMythical { get; }

        public Shape Shape { get; }

        public MorePokemonDetail(int id, string name, FlavorTextEntries[] flavorTextEntries,
         Habitat habitat, bool isLegendary, bool isBaby, bool isMythical, Shape shape)
        {
            Id = id;
            Name = name;
            FlavorTextEntries = flavorTextEntries;
            Habitat = habitat;
            IsLegendary = isLegendary;
            IsBaby = isBaby;
            IsMythical = isMythical;
            Shape = shape;
        }
    }
}