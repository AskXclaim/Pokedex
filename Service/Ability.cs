using System.Text.Json.Serialization;

namespace Service
{
    public class Ability
    {
        [JsonPropertyName("ability")]
        public Ability1 AbilityType { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }

        public int Slot { get; set; }
    }
}