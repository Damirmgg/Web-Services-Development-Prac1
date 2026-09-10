using webapiprac1.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private static readonly List<Game> games = new()
        {
            new Game { Id = 1, Title = "Angry Birds", Genre = "Puzzle", Developer = "Rovio", Year = 2009 },
            new Game { Id = 2, Title = "World of Tanks", Genre = "Action", Developer = "Wargaming", Year = 2010 },
            new Game { Id = 3, Title = "Clash Royale", Genre = "Strategy", Developer = "Supercell", Year = 2016 }
        };

        [HttpGet]
        public ActionResult<List<Game>> GetGames()
        {
            return Ok(games);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<Game> AddGame(Game game)
        {
            game.Id = games.Count + 1;
            games.Add(game);
            return Ok(game);
        }
    }
}