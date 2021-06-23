using System.Text.Json.Serialization;

namespace Pokedex.Service.Models
{
    public class PokedexNumbers
    {
        [JsonPropertyName("entry_number")]
        public int EntryNumber { get; set; }

        public Pokedex Pokedex { get; set; }
    }
}