using System.Text.Json.Serialization;

namespace Pokedex.Service.Models
{
    public class Variety
    {
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        public Pokemon Pokemon { get; set; }
    }
}