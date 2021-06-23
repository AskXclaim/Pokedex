namespace Pokedex.Service.Models
{
    public class PokemonIdentifier
    {
        public Ability[] Abilities { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public Move[] Moves { get; set; }

        public string Name { get; set; }
        public int Weight { get; set; }
    }
}