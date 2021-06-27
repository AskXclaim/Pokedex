using System.Text.Json.Serialization;
using Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces;

namespace Pokedex.Service.Models.InternalModels.PokemonDetail
{
    public class BasicPokemonDetails : IBasicPokemonDetail
    {
        public int Id { get; }
        public string Name { get; }

        [JsonPropertyName("flavor_text_entries")]
        public FlavorTextEntries[] FlavorTextEntries { get; }

        public Habitat Habitat { get; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; }

        public BasicPokemonDetails(int id, string name, FlavorTextEntries[] flavorTextEntries, Habitat habitat, bool isLegendary)
        {
            Id = id;
            Name = name;
            FlavorTextEntries = flavorTextEntries;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }
    }
}