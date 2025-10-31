using UnityEngine;

public class Bomb : MonoBehaviour,ICanSliceObject
{
    public GameObject SlicedBombEffect;
    public GameObject ExplosionEffect;

    [SerializeField]
    private float score = 0;
    float ICanSliceObject.Score { get; set; }

    public float GetScore()
    {
        return ((ICanSliceObject)this).Score;
    }

    private void SetScore(float score)
    {
        ((ICanSliceObject)this).Score = score;
    }

    public void OnSlicing()
    {
        Instantiate(SlicedBombEffect, transform.position, transform.rotation);
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Debug.Log("Bomb has been sliced! Boom!");
        // Add additional logic for when the bomb is sliced
    }
}
