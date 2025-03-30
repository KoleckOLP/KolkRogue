
namespace Gneo
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position() { } // Parameterless constructor

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public (int x, int y) XY()
        {
            return (X, Y);
        }
    }
}