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
    }
}