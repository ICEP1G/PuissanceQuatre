

using CSharpFunctionalExtensions;
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
        public Dictionary<int, ColumnQueue> Grid { get; set; }


        private Dictionary<int, ColumnQueue> Initialize()
        {
            Dictionary<int, ColumnQueue> grid = new();
            for (int i = 0; i < Columns; i++)
            {
                grid[i] = new ColumnQueue();
            }

            return grid;
        }

        //public async Task<bool> VerifyIfGameIsWin()
        //{

        //}

        public bool VerifyVerticalWinCombination()
        {
            foreach (KeyValuePair<int, ColumnQueue> column in Grid)
            {
                if (column.Value.Column.Count < 4)
                    continue;

                TokenColor actualColor = column.Value.Column.Peek().Color;

                int count = 1;
                foreach (Token token in column.Value.Column)
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
                    if (Grid[col].Column.Count > row)
                    {
                        TokenColor color = Grid[col].Column.ToArray()[row].Color;
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

        public bool VerifyDiagonalWinCombination()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (Grid[col].Column.Count > row)
                    {
                        TokenColor color = Grid[col].Column.ToArray()[row].Color;
                        if (CheckDiagonal(Grid, row, col, color, 1, 1) || CheckDiagonal(Grid, row, col, color, 1, -1))
                            return true;
                    }
                }
            }

            return false;
        }

        public bool CheckDiagonal(Dictionary<int, ColumnQueue> board, int startRow, int startCol, TokenColor color, int rowIncrement, int colIncrement)
        {
            int count = 0;
            int row = startRow;
            int col = startCol;

            while (row >= 0 && row < board[0].Column.Count && col >= 0 && col < board.Count)
            {
                if (board[col].Column.Count > row && board[col].Column.ToArray()[row].Color == color)
                {
                    count++;
                    if (count == 4)
                        return true;
                }
                else
                {
                    count = 0;
                }

                row += rowIncrement;
                col += colIncrement;
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
