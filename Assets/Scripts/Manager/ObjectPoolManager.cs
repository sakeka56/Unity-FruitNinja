using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{//TODO：对象池不够时可能会出现问题
    /// <summary>
    /// 预制体
    /// </summary>
    public List<GameObject> prefabList;

    /// <summary>
    /// 对象生成的父物体
    /// </summary>
    public Transform ParentTransform;

    /// <summary>
    /// 水果对象池
    /// </summary>
    Dictionary<FruitType, ObjectPool<Fruit>> FruitPoolDictionary = new Dictionary<FruitType, ObjectPool<Fruit>>();

    /// <summary>
    /// 果汁对象池
    /// </summary>
    Dictionary<FruitType,ObjectPool<Juice>> JuicePoolDictionary = new Dictionary<FruitType, ObjectPool<Juice>>();



    /// <summary>
    /// 炸弹对象池
    /// </summary>
    ObjectPool<Bomb> BombPool;




    protected override void Init()
    {

        if(ParentTransform == null) ParentTransform = transform;

        //初始化对象池
        foreach (var prefab in prefabList)
        {
            FruitType type = prefab.GetComponent<ICanSliceObject>().FruitType;
            if (type == FruitType.Bomb)
            {//炸弹单独处理
                BombPool = new ObjectPool<Bomb>(prefab, 10, 50, ParentTransform);
                Debug.Log("Initialized pool for Bomb");
            }
            else
            {//水果对象池
                FruitPoolDictionary[type] = new ObjectPool<Fruit>(prefab, 10, 50, ParentTransform);
                Debug.Log($"Initialized pool for {type}");

                //创建果汁对象池
                //从Fruit预制体中获取果汁预制体
                Juice juicePrefab = prefab.GetComponent<Fruit>().FruitJuice.GetComponent<Juice>();
                JuicePoolDictionary[type] = new ObjectPool<Juice>(prefab.GetComponent<Fruit>().FruitJuice, 10, 50, ParentTransform);
            }

        }
    }


    public GameObject SpawnFruit(FruitType fruitType,Vector3 position,Quaternion rotation)
    {
        if(!FruitPoolDictionary.ContainsKey(fruitType) && fruitType != FruitType.Bomb)
        {//没有找到对应的对象池
            Debug.LogError($"No pool found for fruit type: {fruitType}");
            return null;
        }

        if(fruitType == FruitType.Bomb)
        {//炸弹单独处理
            return BombPool.Spawn(position, rotation).gameObject;
        }
        return FruitPoolDictionary[fruitType].Spawn(position, rotation).gameObject;
    }

    public GameObject SpawnJuice(FruitType fruitType,Vector3 position,Quaternion rotation)
    {
        if(!JuicePoolDictionary.ContainsKey(fruitType))
        {//没有找到对应的对象池
            Debug.LogError($"No juice pool found for fruit type: {fruitType}");
            return null;
        }
        return JuicePoolDictionary[fruitType].Spawn(position, rotation).gameObject;
    }



    public void Despawn(IPoolable obj)
    {
        if(obj is Bomb bomb)
        {
            BombPool.Despawn(bomb);
        }
        else if(obj is Fruit fruit)
        {
            if(FruitPoolDictionary.ContainsKey(fruit.FruitType))
            {
                FruitPoolDictionary[fruit.FruitType].Despawn(fruit);
            }
            else
            {
                Debug.LogError($"No pool found for fruit type: {fruit.FruitType}");
            }
        }
        else if(obj is Juice juice)
        {
            if(JuicePoolDictionary.ContainsKey(juice.FruitType))
            {
                JuicePoolDictionary[juice.FruitType].Despawn(juice);
            }
            else
            {
                Debug.LogError($"No juice pool found for fruit type: {juice.FruitType}");
            }
        }
        else
        {
            Debug.LogError("Object is neither Bomb nor Fruit.");
        }
    }
}
