

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

        public Task<bool> PlayMove(int row, int column, CellType cellValue)
        {
            (bool isValidMove, Cell? targetedCell) = CheckIfPlayedMoveIsValid(row, column);
            if (isValidMove)
            {
                UpdateCellValue(targetedCell, cellValue);
            }

            return Task.FromResult(isValidMove);
        }

        private (bool isValid, Cell? targetedCell) CheckIfPlayedMoveIsValid(int row, int column)
        {
            Cell? targetedCell = Grid
                .Where(cell => cell.Row == row)
                .Where(Cell => Cell.Column == column)
                .FirstOrDefault();

            if (targetedCell is null)
                return (false, targetedCell);

            if (targetedCell.ColorValue is not null)
                return (false, targetedCell);

            return (true, targetedCell);
        }

        private void UpdateCellValue(Cell targetedCell, CellType cellValue)
        {
            targetedCell.ColorValue = cellValue;
        }

    }
}
