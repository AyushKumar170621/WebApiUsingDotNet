using Microsoft.AspNetCore.Mvc;
using WebApiUsingDotNet.Model;
using WebApiUsingDotNet.Services;

namespace WebApiUsingDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pokemon>> GetAllPokemon()
        {
            return Ok(_pokemonService.GetAllPokemon());
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemon> GetPokemonById(int id)
        {
            var pokemon = _pokemonService.GetPokemonById(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }

        [HttpPost]
        public ActionResult CreatePokemon([FromBody] Pokemon pokemon)
        {
            _pokemonService.CreatePokemon(pokemon);
            return CreatedAtAction(nameof(GetPokemonById), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePokemon(int id, [FromBody] Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return BadRequest();
            }

            _pokemonService.UpdatePokemon(pokemon);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePokemon(int id)
        {
            var existingPokemon = _pokemonService.GetPokemonById(id);
            if (existingPokemon == null)
            {
                return NotFound();
            }

            _pokemonService.DeletePokemon(id);
            return NoContent();
        }
    }
}
