using UnityEngine;

public class Bomb : MonoBehaviour,ICanSliceObject,IPoolable
{
    public GameObject SlicedBombEffect;
    public GameObject ExplosionEffect;

    public FruitType FruitType { get; set; } = FruitType.Bomb;

    [SerializeField]
    private int score = 0;
    int ICanSliceObject.Score { get; set; }

    public int GetScore()
    {
        return ((ICanSliceObject)this).Score;
    }

    private void SetScore(int score)
    {
        ((ICanSliceObject)this).Score = score;
    }

    public void OnSlicing()
    {


        //触发切割事件
        GameManager.Instance.EventManager.TriggerEvent("OnSlicing", this);


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
