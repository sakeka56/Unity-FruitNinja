using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// 游戏帧率
    /// </summary>
    public int FPS = 60;


    /// <summary>
    /// 胜利所需的分数
    /// </summary>
    public float WinScore;


    /// <summary>
    /// 事件管理器
    /// </summary>
    public EventManager EventManager {  get; private set; }
    /// <summary>
    /// 分数管理器
    /// </summary>
    public ScoreManager ScoreManager { get; private set; }






    protected override void Init()
    {
        base.Init();
        EventManager = new EventManager();
        ScoreManager = new ScoreManager(WinScore);


        this.EventManager.Register("OnSlicing", (ob) => { });
        this.EventManager.AddListener("OnSlicing",
            (ob) =>
            {
                Debug.Log(  ((ICanSliceObject)ob).FruitType  + "+" + ((ICanSliceObject)ob).Score);
                ScoreManager.AddScore(((ICanSliceObject)ob).Score);
            });



        Application.targetFrameRate = FPS;

        Debug.Log("Game Manager Inited");
    }

    
   
}
