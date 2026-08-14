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

    // Phase 3: PLayer 1 has Advantage
    [Fact]
    public void GetScore_WhenPlayer1HasAdvantage_ReturnsAdvantagePlayer1()
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        for (int i = 0; i < 3; i++)
        {
            tennis.PointWon("Player 1");
            tennis.PointWon("Player 2");
        }
        tennis.PointWon("Player 1");

        // Assert
        Assert.Equal("Advantage Player 1", tennis.GetScore());
    }
    
    // Phase 3: Player 1 Wins
    [Fact]
    public void GetScore_WhenPlayer1Wins_ReturnsWinForPlayer1()
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        for (int i = 0; i < 4; i++)
        {
            tennis.PointWon("Player 1");
        }

        // Assert
        Assert.Equal("Win for Player 1", tennis.GetScore());
    }

    [Theory]
    [InlineData(4, 4, "Deuce")]
    [InlineData(5, 4, "Advantage Player 1")]
    [InlineData(4, 5, "Advantage Player 2")]
    [InlineData(6, 4, "Win for Player 1")]
    [InlineData(4, 6, "Win for Player 2")]
    public void GetScore_WhenGameIsOver_ReturnsCorrectScore(int player1Points, int player2Points, string expectedScore)
    {
        // Arrange
        var tennis = new Tennis("Player 1", "Player 2");

        // Act
        for (int i = 0; i < player1Points; i++)
        {
            tennis.PointWon("Player 1");
        }
        for (int i = 0; i < player2Points; i++)
        {
            tennis.PointWon("Player 2");
        }

        // Assert
        Assert.Equal(expectedScore, tennis.GetScore());
    }
}
