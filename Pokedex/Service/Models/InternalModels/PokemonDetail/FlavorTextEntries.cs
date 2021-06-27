using System.Text.Json.Serialization;

namespace Pokedex.Service.Models.InternalModels.PokemonDetail
{
    public class FlavorTextEntries
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        public Language Language { get; set; }
    }
}