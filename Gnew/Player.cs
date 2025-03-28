namespace Gnew
{
    public class Player
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Health { get; set; }

        public Player(int row, int col, int health = 100) 
        {
            Row = row;
            Col = col;
            Health = health;
        }
    }
}
