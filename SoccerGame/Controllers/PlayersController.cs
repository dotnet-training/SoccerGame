namespace SoccerGame.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public virtual async Task<Player> Post([FromBody] Player player)
        {
            var playerEntity = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return playerEntity.Entity;
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> Get()
        {
            return await _context.Players.ToListAsync();
        }

    }
}