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
            return "Deuce";    
        }

        // Advantage or Win situation
        if (_player1Score >= 4 || _player2Score >= 4)
        {
            int scoreDifference = _player1Score - _player2Score;
            if (scoreDifference == 1)
            {
                return $"Advantage {_player1}";
            }
            else if (scoreDifference == -1)
            {
                return $"Advantage {_player2}";
            }
            else if (scoreDifference >= 2)
            {
                return $"Win for {_player1}";
            }
            else
            {
                return $"Win for {_player2}";
            }
        }

        // Different scores <4 points
        return $"{ScoreNames[_player1Score]}-{ScoreNames[_player2Score]}";
    }

    private bool TieScore() => _player1Score == _player2Score;

    private string GetTieScore()
    {
        if (_player1Score < 3)
        {
            return $"{ScoreNames[_player1Score]}-All";
        }
        return "Deuce";
    }

    private bool EndGame() => _player1Score >= 4 || _player2Score >= 4;

    private string GetEndGameScore()
    {
        int scoreDifference = _player1Score - _player2Score;
        
        return scoreDifference switch
        {
            1 => $"Advantage {_player1}",
            -1 => $"Advantage {_player2}",
            >= 2 => $"Win for {_player1}",
            _ => $"Win for {_player2}"
        };
    }
}
