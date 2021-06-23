using System.Text.Json.Serialization;

namespace Service
{
    public class Move
    {
        [JsonPropertyName("move")]
        public Move1 MoveType { get; set; }
    }
}