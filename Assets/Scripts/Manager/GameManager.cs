using UnityEngine;

public class GameManager : Singleton<GameManager>
{
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


        this.EventManager.Register("OnSlicing", (ob) => Debug.Log(ob.GetType()));
        this.EventManager.AddListener("OnSlicing",
            (ob) =>
            {
                Debug.Log(ob.GetType()  + "+" + ((ICanSliceObject)ob).Score);
                ScoreManager.AddScore(((ICanSliceObject)ob).Score);
            });

        Debug.Log("Game Manager Inited");
    }

    
   
}
