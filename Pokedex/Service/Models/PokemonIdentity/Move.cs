using System.Text.Json.Serialization;

namespace Pokedex.Service.Models
{
    public class Move
    {
        [JsonPropertyName("move")]
        public MoveType MoveType { get; set; }
    }
}