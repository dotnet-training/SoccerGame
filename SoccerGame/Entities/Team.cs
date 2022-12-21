namespace SoccerGame
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }

        public List<Player> Players { get; set; }
    }
}