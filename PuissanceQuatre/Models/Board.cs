

using System.Data.Common;

namespace PuissanceQuatre.Models
{
    public class Board
    {
        public Board() 
        {
            Grid = Initialize();
        }

        private const int Rows = 6;
        private const int Columns = 7;
        public Dictionary<int, PowerStack> Grid { get; set; }


        private Dictionary<int, PowerStack> Initialize()
        {
            Dictionary<int, PowerStack> grid = new();
            for (int i = 0; i < Columns; i++)
            {
                grid[i] = new PowerStack();
            }

            return grid;
        }

        //public async Task<bool> VerifyIfGameIsWin()
        //{

        //}

        public bool VerifyVerticalWinCombination()
        {
            foreach (KeyValuePair<int, PowerStack> column in Grid)
            {
                if (column.Value.Stack.Count < 4)
                    continue;

                TokenColor actualColor = column.Value.Stack.Peek().Color;

                int count = 1;
                foreach (Token token in column.Value.Stack)
                {
                    if (actualColor.Equals(token.Color))
                    {
                        count++;
                        if (count == 4)
                            return true;
                    }
                    else
                    {
                        actualColor = token.Color;
                        count = 1;
                    }
                }
            }

            return false;
        }

        public bool VerifyHorizontalWinCombination()
        {
            for (int row = 0; row < Rows; row++)
            {
                int count = 0;
                TokenColor? actualColor = null;

                for (int col = 0; col < Columns; col++)
                {
                    if (Grid[col].Stack.Count > row)
                    {
                        TokenColor color = Grid[col].Stack.ToArray()[row].Color;
                        if (actualColor is null)
                        {
                            actualColor = color;
                            count = 1;
                        }
                        else if (actualColor == color)
                        {
                            count++;
                            if (count == 4)
                                return true;
                        }
                        else
                        {
                            actualColor = color;
                            count = 1;
                        }
                    }
                    else
                    {
                        actualColor = null;
                        count = 0;
                    }
                }
            }
            
            return false;
        }

        //public Task<bool> PlayMove(int row, int column, CellType cellValue)
        //{
        //    (bool isValidMove, Cell? targetedCell) = CheckIfPlayedMoveIsValid(row, column);
        //    if (isValidMove)
        //    {
        //        UpdateCellValue(targetedCell, cellValue);
        //    }

        //    return Task.FromResult(isValidMove);
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
