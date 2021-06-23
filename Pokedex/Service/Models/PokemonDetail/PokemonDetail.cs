using System.Text.Json.Serialization;

namespace Pokedex.Service.Models
{
    public class PokemonDetail
    {
        [JsonPropertyName("flavor_text_entries")]
        public FlavorTextEntries[] FlavorTextEntries { get; set; }

        public Genera[] Genera { get; set; }
        public Habitat Habitat { get; set; }

        [JsonPropertyName("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [JsonPropertyName("hatch_counter")]
        public int HatchCounter { get; set; }

        public int Id { get; set; }

        [JsonPropertyName("is_baby")]
        public bool IsBaby { get; set; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; set; }

        [JsonPropertyName("is_mythical")]
        public bool IsMythical { get; set; }

        public string Name { get; set; }
        public Shape Shape { get; set; }
        public Variety[] Varieties { get; set; }
    }
}