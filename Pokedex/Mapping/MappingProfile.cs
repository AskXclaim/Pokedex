using AutoMapper;
using Pokedex.Application.Models.Instances;

namespace Pokedex.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokemonModel, Models.Instances.PokemonModel>();
            CreateMap<PokemonModel, Models.Instances.TranslatedPokemonModel>();
        }
    }
}