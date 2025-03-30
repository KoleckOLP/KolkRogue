
namespace Gneo
{
    public class Trap
    {
        public Position Position { get; set; }
        public MapTile Symbol { get; set; }

        public Trap(Position position, MapTile symbol = MapTile.Trap)
        {
            Position = position;
            Symbol = symbol;
        }
    }
}
