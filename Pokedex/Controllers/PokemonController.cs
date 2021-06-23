using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Models.Interfaces;
using Pokedex.Service.Infrastructure.Interfaces;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _service;

        public PokemonController(IPokemonService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IBasicDetail>> GetPokemon(string name)
        {
            if (!IsNameValid(name)) return BadRequest(ModelState);

            var result = await _service.IdentifyPokemon(name);
            var finalResult = await _service.GetPokemonDetail(result.Id);
            return (new PokemonModel(name, "description", "habitat", false));
        }

        private bool IsNameValid(string name)
        {
            if (!ModelState.IsValid) return false;

            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError($"{nameof(name)}", $"Please supply a poke name in english");
                return false;
            }

            if (name.IsAlphabetic()) return true;

            ModelState.AddModelError($"{nameof(name)}", $"Please supply pokemon name in english");
            return false;
        }

        [Route("translated/{name}")]
        [HttpGet]
        public async Task<ActionResult<IMoreDetail>> GetTranslatedPokemon(string name)
        {
            if (IsNameValid(name)) return BadRequest(ModelState);

            var result = await _service.IdentifyPokemon(name);
            var finalResult = await _service.GetPokemonDetail(result.Id);
            return (new DetailedPokemonModel(name, "description", "habitat", false, 3, 20));
        }
    }
}