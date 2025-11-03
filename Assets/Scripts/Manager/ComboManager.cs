using System;
using System.Collections;
using UnityEngine;

public class ComboManager: IManager
{
    public int ComboCount {  get; private set; }
    public int HighestComboCount { get; private set; }

    private float ComboDelayTimer = 0;
    private float ComboMaxDelayTime = 2;

    public Action<int> OnCombo;


    public void Init()
    {
        ComboCount = 0;
    }

    public void DoUpdate()
    {
        ComboJudge();
    }

    public void IncrementCombo(object ob)
    {
        if(ob is Bomb)
        {
            Reset();
            return;
        }
        ComboCount++;

        //连续
        ComboDelayTimer = 0;

        OnCombo?.Invoke(ComboCount);
    }

    public void SetComboMaxDelayTime(float time)
    {
        ComboMaxDelayTime = time;
    }

    public void Reset()
    {
        //记录最高连击数量
        HighestComboCount = Mathf.Max(HighestComboCount, ComboCount);
        ComboCount = 0;
    }

    void ComboJudge()
    {
        ComboDelayTimer += Time.deltaTime;

        if (ComboDelayTimer >= ComboMaxDelayTime)
        {
            Reset();
        }
    }

}
