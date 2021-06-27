using AutoMapper;
using Pokedex.Application.Models.Instances;

namespace Pokedex.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BasicPokemonModel, Models.Instances.BasicPokemonModel>();
            CreateMap<DetailedPokemonModel, Models.Instances.DetailedPokemonModel>();
        }
    }
}