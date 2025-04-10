
namespace Gneo
{
    public class Visibility
    {
        public int Xmin { get; set; }
        public int Xmax { get; set; }
        public int Ymin { get; set; }
        public int Ymax { get; set; }

        // Constructor to initialize all values to 0
        public Visibility(int xmin = 0, int xmax = 0, int ymin = 0, int ymax = 0)
        {
            Xmin = xmin;
            Xmax = xmax;
            Ymin = ymin;
            Ymax = ymax;
        }
    }
}
