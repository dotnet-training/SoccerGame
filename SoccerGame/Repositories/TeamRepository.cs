namespace SoccerGame.Repositories
{
    using Microsoft.EntityFrameworkCore;
    public interface ITeamRepository
    {
        Task<Team> Add(Team team);
        Task Delete(Guid id);
        Task<IEnumerable<Team>> Get();
        Task<Team> Get(Guid id);
        Task<Team> Update(Team team);
    }

    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> Add(Team team)
        {
            var teamEntity = await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return teamEntity.Entity;
        }

        public async Task<IEnumerable<Team>> Get()
        {
            return await _context.Teams.ToListAsync();
        }

        public virtual async Task<Team> Get(Guid id)
        {
            return await _context.Teams
                .Include(team => team.Players)
                .SingleOrDefaultAsync(team => team.Id == id);
        }

        public async Task<Team> Update(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task Delete(Guid id)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);
            if (team == default)
            {
                return;
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }
    }
}