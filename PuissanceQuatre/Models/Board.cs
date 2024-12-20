

namespace PuissanceQuatre.Models
{
    public class Board
    {
        public Board() 
        { 
            Grid = Initalize();
        }

        public List<Cell> Grid { get; set; }


        private List<Cell> Initalize()
        {
            List<Cell> grid = new();
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    grid.Add(new Cell(row, column));
                }
            }

            return grid;
        }
    }
}
