using System.Text.Json.Serialization;
using Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces;

namespace Pokedex.Service.Models.InternalModels.PokemonDetail
{
    /// <summary>
    ///  A class that mirrors the Root class gotten from an external API call.<br/>
    /// It can be used to hold a Pokemon's details, this is only used internally with the service namespace.
    /// </summary>
    public class PokemonDetail : IPokemonDetail
    {
        public int Id { get; }
        public string Name { get; }

        [JsonPropertyName("flavor_text_entries")]
        public FlavorTextEntries[] FlavorTextEntries { get; }

        public Habitat Habitat { get; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; }

        public Shape Shape { get; }

        [JsonPropertyName("is_Baby")]
        public bool IsBaby { get; }

        [JsonPropertyName("is_Mythical")]
        public bool IsMythical { get; }

        public PokemonDetail(int id, string name, FlavorTextEntries[] flavorTextEntries,
         Habitat habitat, bool isLegendary, Shape shape, bool isBaby, bool isMythical)
        {
            Id = id;
            Name = name;
            FlavorTextEntries = flavorTextEntries;
            Habitat = habitat;
            Shape = shape;
            IsLegendary = isLegendary;
            IsBaby = isBaby;
            IsMythical = isMythical;
        }
    }
}