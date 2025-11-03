using UnityEngine;

public class ScoreManager : IManager
{
    
    /// <summary>
    /// 当前分数
    /// </summary>
    public int Score
    {
        get;
        private set;
    }

    /// <summary>
    /// 胜利所需分数
    /// </summary>
    public int WinScore
    {
        get;
        private set;
    }

    public void Init()
    {
    }

    

    public ScoreManager(int WinScore)
    {
        this.WinScore = WinScore;
    }

    /// <summary>
    /// 添加分数
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public int AddScore(int score)
    {
        Score += score;
        return Score;
    }
    /// <summary>
    /// 减少分数
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public int SubScore(int score)
    {
        Score -= score;
        return Score;
    }

    /// <summary>
    /// 将分数归零
    /// </summary>
    public void ClearScore()
    {
        Score = 0;
    }
}
