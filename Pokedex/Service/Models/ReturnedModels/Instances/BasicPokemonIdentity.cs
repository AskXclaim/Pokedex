using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Service.Models.ReturnedModels.Instances
{
    /// <summary>
    /// A [Service] model class to use to hold basic pokemon details.<br/>
    /// This model is returned out.
    /// </summary>
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