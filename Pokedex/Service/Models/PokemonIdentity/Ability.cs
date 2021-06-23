using System.Text.Json.Serialization;

namespace Pokedex.Service.Models
{
    public class Ability
    {
        [JsonPropertyName("ability")]
        public AbilityType AbilityType { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }
    }
}