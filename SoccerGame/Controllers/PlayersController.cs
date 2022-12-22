namespace SoccerGame.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoccerGame.Repositories;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpPost]
        public virtual async Task<Player> Post([FromBody] Player player)
        {
            return await _playerRepository.Add(player);
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> Get()
        {
            return await _playerRepository.Get();
        }

        [HttpGet("{id}")]
        public virtual async Task<Player> Get(Guid id)
        {
            return await _playerRepository.Get(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Player player)
        {
            return Ok(await _playerRepository.Update(player));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _playerRepository.Delete(id);
            return Ok();
        }
    }
}