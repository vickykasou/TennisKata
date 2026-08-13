using TennisKata.Core;
using Xunit;

namespace TennisKata.Tests;

public class TennisTests
{
    // Starting state
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

    // Phase 1: Player 1 scores
    [Fact]
    public void GetScore_WhenPlayer1Scores_ReturnsFifteenLove()
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        tennis.PointWon("Player 1");
        string score = tennis.GetScore();

        // Assert
        Assert.Equal("Fifteen-Love", score);
    }
}