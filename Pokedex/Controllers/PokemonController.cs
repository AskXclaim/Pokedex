using System.Threading.Tasks;
using AutoMapper;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Models.Instances;
using Pokedex.Models.Interfaces;

namespace Pokedex.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonDetailRepository _detailRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonDetailRepository detailRepository, IMapper mapper)
        {
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        [HttpGet("{pokemonName}")]
        public async Task<ActionResult<IBasicPokemonDetails>> GetPokemon(string pokemonName)
        {
            if (!IsNameValid(pokemonName)) return BadRequest(ModelState);

            var result = await _detailRepository.GetBasicPokemonDetails(pokemonName);

            if (result != null && result.HasError) return NotFound(result.Error);

            return Ok(_mapper.Map<BasicPokemonModel>(result));
        }

        [Route("translated/{pokemonName}")]
        [HttpGet]
        public async Task<ActionResult<IMorePokemonDetails>> GetTranslatedPokemon(string pokemonName)
        {
            if (!IsNameValid(pokemonName)) return BadRequest(ModelState);

            var result = await _detailRepository.GetTranslatedPokemonDetails(pokemonName);

            if (result != null && result.HasError) return NotFound(result.Error);

            return Ok(_mapper.Map<DetailedPokemonModel>(result));
        }

        private bool IsNameValid(string pokemonName)
        {
            if (!ModelState.IsValid) return false;

            if (string.IsNullOrWhiteSpace(pokemonName))
            {
                ModelState.AddModelError($"{nameof(pokemonName)}", Constants.PokemonNameRequired);
                return false;
            }

            if (pokemonName.IsAlphabetic()) return true;

            ModelState.AddModelError($"{nameof(pokemonName)}", Constants.PokemonNameIsRequiredInEnglish);
            return false;
        }
    }
}