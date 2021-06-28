using System.Text.Json.Serialization;

namespace Pokedex.Service.Models.InternalModels.PokemonDetail
{
    /// <summary>
    /// A class that mirrors some of the information of the Flavor_Text_Entries class gotten from an external API call.
    /// </summary>
    public class FlavorTextEntries
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        public Language Language { get; set; }
    }
}