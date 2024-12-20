

namespace PuissanceQuatre.Models
{
    public class Board
    {
        //public Board() 
        //{ 
        //    Grid = Initalize();
        //}

        //private const int Rows = 6;
        //private const int Cols = 7;
        //public Dictionary<int, Stack<int>[]> Grid;


        //private Dictionary<int, Stack<int>> Initalize()
        //{
        //    Dictionary<int, Stack<int>> grid = new();
        //    for (int i = 0; i < Cols; i++)
        //    {
        //        grid[i] = new Stack<int>();
        //    }

        //    return grid;
        //}

        //public Task<bool> PlayMove(int row, int column, CellType cellValue)
        //{
        //    (bool isValidMove, Cell? targetedCell) = CheckIfPlayedMoveIsValid(row, column);
        //    if (isValidMove)
        //    {
        //        UpdateCellValue(targetedCell, cellValue);
        //    }

        //    return Task.FromResult(isValidMove);
        //}

        //private (bool isValid, Cell? targetedCell) CheckIfPlayedMoveIsValid(int row, int column)
        //{
        //    Cell? targetedCell = Grid
        //        .Where(cell => cell.Row == row)
        //        .Where(Cell => Cell.Column == column)
        //        .FirstOrDefault();

        //    if (targetedCell is null)
        //        return (false, targetedCell);

        //    if (targetedCell.ColorValue is not null)
        //        return (false, targetedCell);

        //    return (true, targetedCell);
        //}

        //private void UpdateCellValue(Cell targetedCell, CellType cellValue)
        //{
        //    targetedCell.ColorValue = cellValue;
        //}

    }
}
