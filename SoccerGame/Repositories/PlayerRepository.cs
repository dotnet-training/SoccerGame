namespace SoccerGame.Repositories
{
    using Microsoft.EntityFrameworkCore;

    public interface IPlayerRepository
    {
        Task<Player> Add(Player player);
        Task Delete(Guid id);
        Task<IEnumerable<Player>> Get();
        Task<Player> Get(Guid id);
        Task<Player> Update(Player player);
    }

    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> Add(Player player)
        {
            var playerEntity = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return playerEntity.Entity;
        }

        public async Task<IEnumerable<Player>> Get()
        {
            return await _context.Players.ToListAsync();
        }

        public virtual async Task<Player> Get(Guid id)
        {
            return await _context.Players
                .Include(player => player.Team)
                .SingleOrDefaultAsync(player => player.Id == id);
        }

        public async Task<Player> Update(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task Delete(Guid id)
        {
            Player player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
            if (player == default)
            {
                return;
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}