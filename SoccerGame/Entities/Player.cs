namespace SoccerGame
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }
        public Foot Foot { get; set; }
        public Position Position { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }

    public enum Foot
    {
        Right,
        Left,
        Both
    }

    public enum Position
    {
        GK,
        CB,
        CF
    }
}