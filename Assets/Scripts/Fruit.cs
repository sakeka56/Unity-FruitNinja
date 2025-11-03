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

public class Fruit : MonoBehaviour,ICanSliceObject,IPoolable
{
    public GameObject SlicedFruit;
    public GameObject FruitJuice;

    [SerializeField]
    private FruitType fruitType;
    public FruitType FruitType { get => fruitType; set => fruitType = value; }
    public float explosionForce = 50f;

    private Rigidbody Rigidbody;

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

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        FruitType = fruitType;
        SetScore(score);
    }
    public void OnSlicing()
    {
        //触发切割事件
        GameManager.Instance.EventManager.TriggerEvent("OnSlicing", this);

        //生成切割后的水果
        var fruit = Instantiate(SlicedFruit, transform.position, transform.rotation);


        //生成对应的果汁
        //var juice = Instantiate(FruitJuice, transform.position, FruitJuice.transform.rotation);
        var juice = ObjectPoolManager.Instance.SpawnJuice(FruitType,transform.position,default(Quaternion));

        juice.GetComponent<Juice>().FruitType = fruitType;


        Rigidbody[] rbs = fruit.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbs)
        {
            rb.AddExplosionForce(explosionForce, transform.position, 5f);
            //rb.angularVelocity = Rigidbody.angularVelocity;
            rb.linearVelocity = Rigidbody.linearVelocity;
        }

        //Destroy(gameObject);
        ObjectPoolManager.Instance.Despawn(this);


    }

    public void OnSpawn()
    {
        Rigidbody.isKinematic = false;
    }

    public void OnDespawn()
    {
        Rigidbody.angularVelocity = Vector3.zero;
        Rigidbody.linearVelocity = Vector3.zero;
        Rigidbody.isKinematic = true;
    }
}
