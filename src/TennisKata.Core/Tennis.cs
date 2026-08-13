namespace TennisKata.Core;

public class Tennis
{
    private readonly string _player1;
    private readonly string _player2;

    public Tennis(string player1, string player2)
    {
        _player1 = player1;
        _player2 = player2;
    }

    public string GetScore()
    {
        return "Love all";
    }
}