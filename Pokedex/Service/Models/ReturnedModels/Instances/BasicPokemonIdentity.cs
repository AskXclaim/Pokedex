using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Models.ReturnedModels.Instances
{
    public class BasicPokemonIdentity : IBasicPokemonIdentity
    {
        public int Id { get; }
        public string Name { get; }

        public BasicPokemonIdentity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}