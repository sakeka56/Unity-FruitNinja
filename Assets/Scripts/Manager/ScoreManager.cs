using UnityEngine;

public class ScoreManager : IManager
{
    
    /// <summary>
    /// 当前分数
    /// </summary>
    public float Score
    {
        get;
        private set;
    }

    /// <summary>
    /// 胜利所需分数
    /// </summary>
    public float WinScore
    {
        get;
        private set;
    }

    public void Init()
    {
    }

    

    public ScoreManager(float WinScore)
    {
        this.WinScore = WinScore;
    }

    /// <summary>
    /// 添加分数
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public float AddScore(float score)
    {
        Score += score;
        return Score;
    }
    /// <summary>
    /// 减少分数
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public float SubScore(float score)
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
