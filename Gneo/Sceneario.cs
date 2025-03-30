
namespace Gneo
{
    public class Scenario
    {
        public Player? Player { get; set; }
        public List<Trap> Traps { get; set; } = new List<Trap>();

        public Scenario() { } // for JSON serilizer

        public Scenario(Player player, params Trap[] traps)
        {
            Player = player;
            Traps.AddRange(traps);
        }

        public Scenario(Player player, List<Trap> traps)
        {
            Player = player;
            Traps = traps;
        }

        public void AddTrap(Trap trap)
        {
            Traps.Add(trap);
        }

        public void RemoveTrap(Trap trap)
        {
            Traps.Remove(trap);
        }
    }
}