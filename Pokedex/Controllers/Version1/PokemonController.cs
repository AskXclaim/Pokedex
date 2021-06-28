using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Models.Instances;
using Pokedex.Models.Interfaces;

namespace Pokedex.Controllers.Version1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
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

        /// <summary>
        /// Get basic pokemon information  /pokemon/{pokemonName}
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>

        [HttpGet("{pokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IBasicPokemonDetails>> GetPokemon(string pokemonName)
        {
            if (!IsNameValid(pokemonName)) return BadRequest(ModelState);

            var result = await _detailRepository.GetBasicPokemonDetails(FormatPokemonName(pokemonName));

            if (result != null && result.HasError) return NotFound(result.Error);

            return Ok(_mapper.Map<BasicPokemonModel>(result));
        }

        /// <summary>
        /// Get detailed pokemon information  /pokemon/translated/{pokemonName}
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>

        [HttpGet("translated/{pokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IMorePokemonDetails>> GetTranslatedPokemon(string pokemonName)
        {
            if (!IsNameValid(pokemonName)) return BadRequest(ModelState);

            var result = await _detailRepository.GetTranslatedPokemonDetails(FormatPokemonName(pokemonName));

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

            if (Regex.IsMatch(pokemonName, @"^[a-zA-Z]+$")) return true;

            ModelState.AddModelError($"{nameof(pokemonName)}", Constants.PokemonNameShouldBeAlphabetsOnly);
            return false;
        }

        private string FormatPokemonName(string pokemonName) => pokemonName.Trim().ToLower();
    }
}