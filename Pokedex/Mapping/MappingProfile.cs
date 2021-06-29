using AutoMapper;
using Pokedex.Models.Instances;
using PokemonModel = Pokedex.Application.Models.Instances.PokemonModel;

namespace Pokedex.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokemonModel, Models.Instances.PokemonModel>();
            CreateMap<PokemonModel, TranslatedPokemonModel>();
        }
    }
}