
namespace Gneo
{
    public class Player
    {
        public Position Position { get; set; }
        public int Health { get; set; }
        public MapTile Symbol { get; set; }

        public Player(Position position, int health = 100, MapTile symbol = MapTile.Player)
        {
            Position = position;
            Health = health;
            Symbol = symbol;
        }
    }
}
