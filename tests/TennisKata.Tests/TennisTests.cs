using TennisKata.Core;
using Xunit;

namespace TennisKata.Tests;

public class TennisTests
{
    [Fact]
    public void GetScore_ShouldReturnNotImplementedMessage()
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        var score = tennis.GetScore();

        // Assert
        Assert.Equal("Love all", score);
    }
}