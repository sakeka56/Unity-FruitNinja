using System.Collections;
using UnityEngine;



public enum FruitType
{
    Apple,
    Coconut,
    Orange,
    Pear,
    Watermelon,

    Bomb
}

public class Fruit : MonoBehaviour,ICanSliceObject
{
    public GameObject SlicedFruit;
    public GameObject FruitJuice;

    public FruitType FruitType;
    public float explosionForce = 50f;

    private Rigidbody Rigidbody;

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

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    public void OnSlicing()
    {
        GameManager.Instance.EventManager.TriggerEvent("OnSlicing", this);

        var fruit = Instantiate(SlicedFruit, transform.position, transform.rotation);
        var juice = Instantiate(FruitJuice, transform.position, FruitJuice.transform.rotation);

        Rigidbody[] rbs = fruit.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbs)
        {
            rb.AddExplosionForce(explosionForce, transform.position, 3f);
            //rb.angularVelocity = Rigidbody.angularVelocity;
            rb.linearVelocity = Rigidbody.linearVelocity;
        }

        Destroy(gameObject);


    }


}
