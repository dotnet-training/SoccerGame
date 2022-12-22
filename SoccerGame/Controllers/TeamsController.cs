namespace SoccerGame.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoccerGame.Repositories;

    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpPost]
        public virtual async Task<Team> Post([FromBody] Team team)
        {
            return await _teamRepository.Add(team);
        }

        [HttpGet]
        public async Task<IEnumerable<Team>> Get()
        {
            return await _teamRepository.Get();
        }

        [HttpGet("{id}")]
        public virtual async Task<Team> Get(Guid id)
        {
            return await _teamRepository.Get(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Team team)
        {
            return Ok(await _teamRepository.Update(team));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _teamRepository.Delete(id);
            return Ok();
        }
    }
}