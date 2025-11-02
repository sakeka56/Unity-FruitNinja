using UnityEngine;

public class Bomb : MonoBehaviour,ICanSliceObject,IPoolable
{
    public GameObject SlicedBombEffect;
    public GameObject ExplosionEffect;

    public FruitType FruitType { get; set; } = FruitType.Bomb;

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
        GameObject effect = null;
        //if(SlicedBombEffect != null) Instantiate(SlicedBombEffect, transform.position, transform.rotation);
        if (ExplosionEffect != null) 
        {
            effect = Instantiate(ExplosionEffect, transform.position, transform.rotation); 
            effect.GetComponent<ParticleSystem>().Play();
        }
        Debug.Log("Bomb has been sliced! Boom!");
        // Add additional logic for when the bomb is sliced

        Destroy(effect, 1);
        Destroy(this.gameObject, 2);
        this.gameObject.SetActive(false);

    }

    public void OnSpawn()
    {
        
    }

    public void OnDespawn()
    {
        
    }
}
