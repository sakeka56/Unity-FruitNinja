using UnityEngine;

public interface ICanSliceObject 
{
    FruitType FruitType { get; set; }
    int Score { get; set; }

    //实现Score请使用
    //[SerializeField]
    //private float score = 0;
    //float ICanSliceObject.Score { get; set; }

    //public float GetScore()
    //{
    //    return ((ICanSliceObject)this).Score;
    //}

    //private void SetScore(float score)
    //{
    //    ((ICanSliceObject)this).Score = score;
    //}
    public void OnSlicing();


}
