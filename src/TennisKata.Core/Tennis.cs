namespace TennisKata.Core;

public class Tennis
{
    private readonly string _player1;
    private readonly string _player2;

    // 2 integers for scoring
    private int _player1Score = 0;
    private int _player2Score = 0;

    private static readonly string[] ScoreNames = { "Love", "Fifteen", "Thirty", "Forty" };

    public Tennis(string player1, string player2)
    {
        _player1 = player1;
        _player2 = player2;
    }

    public void PointWon(string player)
    {
        if (player == _player1)
        {
            _player1Score++;
        }
        else if (player == _player2)
        {
            _player2Score++;
        }
    }
    public string GetScore()
    {
        // Scores are equal <3 points
        if (_player1Score == _player2Score)
        {
            if (_player1Score < 3)
            {
                return $"{ScoreNames[_player1Score]}-All";
            }
            else
            {
                return "Deuce";
            }
        }

        // Different scores <4 points
        return $"{ScoreNames[_player1Score]}-{ScoreNames[_player2Score]}";
    }
}