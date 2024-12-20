using FluentAssertions;
using PuissanceQuatre.Models;

namespace PuissanceQuatre.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Initialize_ReturnGrid6by7()
        {
            // Arrange

            // Act
            Board board = new();

            // Assert
            board.Grid
                .Should()
                .NotBeNull();
            board.Grid
                .Should()
                .HaveCount(42);
            board.Grid.Where(cell => cell.ColorValue is null)
                .Should()
                .HaveCount(42);
        }

        [Fact]
        public async Task PlayerMove_IsValidMove_ShouldFillTheGrid()
        {
            // Arrange
            Board board = new();

            // Act
            bool isValidMove = await board.PlayMove(1 ,1, CellType.Red);

            // Assert
            isValidMove.Should().BeTrue();
            board.Grid
                .First(cell => cell.Row == 1 && cell.Column == 1)
                .ColorValue
                .Should()
                .Be(CellType.Red);
        }

        [Fact]
        public async Task PlayerMove_IsNotValidMove_ShouldNotFillTheGrid()
        {
            // Arrange
            Board board = new();

            // Act
            bool isValidMove = await board.PlayMove(66, -4, CellType.Red);

            // Assert
            isValidMove.Should().BeFalse();
        }

        [Fact]
        public void PlayerMove_IsAlreadyFilled_ShouldNotFillTheGrid()
        {
            // Arrange
            Board board = new();
            Cell cell = board.Grid.First(cell => cell.Column == 1 && cell.Row == 1);
            cell.ColorValue = CellType.Red;

            // Act
            board.PlayMove(1, 1, CellType.Red);

            // Assert
            board.Grid.First(cell => cell.Row == 1 && cell.Column == 1)
                .ColorValue
                .Should()
                .Be(CellType.Red);
        }


    }
}