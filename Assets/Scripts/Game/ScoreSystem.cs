

using UnityEngine;

public class ScoreSystem 
{
    private const string MAX_SCORE_KEY = "MaxScore";
    public int Score { get; private set; }
    public int MaxScore { get; private set; }

    public void StartGame()
    {
        Score = 0;
        PlayerPrefs.GetInt(MAX_SCORE_KEY, 0);
    }

    public void EndGame()
    {
        if (Score > MaxScore)
        {
            MaxScore = Score;
            PlayerPrefs.SetInt(MAX_SCORE_KEY, MaxScore);
        }
    }

    public void AddScore(int earnedScore)
    {
        Score += earnedScore;
    }
}
