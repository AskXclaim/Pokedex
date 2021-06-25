using System.Threading.Tasks;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Models.Interfaces;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        private readonly IPokemonProcessor _processor;

        public PokemonController(IPokemonProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet("{pokemonName}")]
        public async Task<ActionResult<IBasicPokemonDetail>> GetPokemon(string pokemonName)
        {
            if (!IsNameValid(pokemonName)) return BadRequest(ModelState);

            var result = await _processor.GetBasicPokemonDetail(pokemonName);

            if (result != null && !string.IsNullOrWhiteSpace(result.Error))
                return NotFound(result);

            return Ok(result);
        }

        [Route("translated/{pokemonName}")]
        [HttpGet]
        public async Task<ActionResult<IMorePokemonDetail>> GetTranslatedPokemon(string pokemonName)
        {
            if (IsNameValid(pokemonName)) return BadRequest(ModelState);

            var result = await _processor.GetPokemonDetail(pokemonName);

            if (result != null && !string.IsNullOrWhiteSpace(result.Error))
                return NotFound(result);

            return Ok(result);
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