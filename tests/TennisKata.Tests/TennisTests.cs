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
        Assert.Equal("Love-All", score);
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

    // Phase 1: Both players score
    [Fact]
    public void GetScore_WhenBothPlayersScore1_ReturnsFifteenAll()
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        tennis.PointWon("Player 1");
        tennis.PointWon("Player 2");

        // Assert
        Assert.Equal("Fifteen-All", tennis.GetScore());
    }

    // Phase 1: Player 1 scores twice, Player 2 scores once
    [Fact]
    public void GetScore_WhenPlayer1ScoresTwiceAndPlayer2ScoresOnce_ReturnsThirtyFifteen()
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        tennis.PointWon("Player 1");
        tennis.PointWon("Player 1");
        tennis.PointWon("Player 2");

        // Assert
        Assert.Equal("Thirty-Fifteen", tennis.GetScore());
    }

    // Phase 2: Both players score three times
    [Fact]
    public void GetScore_WhenBothPlayersScoreThreeTimes_ReturnsDeuce()
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        tennis.PointWon("Player 1");
        tennis.PointWon("Player 1");
        tennis.PointWon("Player 1");
        tennis.PointWon("Player 2");
        tennis.PointWon("Player 2");
        tennis.PointWon("Player 2");

        // Assert
        Assert.Equal("Deuce", tennis.GetScore());
    }
    
}