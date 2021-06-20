using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Models.Interfaces;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        [HttpGet("{name}")]
        public async Task<ActionResult<IBasicDetail>> GetPokemon(string name)
        {
            return (new PokemonModel(name, "description", "habitat", false));
        }
    }
}