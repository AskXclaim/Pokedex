using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Service.Models.Interfaces;

namespace Pokedex.Service.Models.Instances
{
    public class PokemonDetail : IPokemonDetail
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }
        public bool IsLegendary { get; }

        public PokemonDetail(string name, string description, string habitat, bool isLegendary)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }
    }
}