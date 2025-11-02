using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component, IPoolable
{
    /// <summary>
    /// 对象预制体
    /// </summary>
    private GameObject prefab;

    /// <summary>
    /// 对象池最大尺寸
    /// </summary>
    private int maxSize;

    /// <summary>
    /// 对象池父物体
    /// </summary>
    private Transform parent;
    /// <summary>
    /// 已创建对象数量
    /// </summary>
    private int CreatedObjects = 0;
    private Queue<T> poolQueue = new Queue<T>();







    public ObjectPool(GameObject prefab, int initialSize, int maxSize = 0, Transform parent = null)
    {
        this.prefab = prefab;
        for (int i = 0; i < initialSize; i++)
        {
            CreateNewObject();
        }
    }


    /// <summary>
    /// 向对象池内新建一个对象
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.InvalidOperationException"></exception>
    private T CreateNewObject()
    {
        if(maxSize > 0 && CreatedObjects >= maxSize)
        {//达到最大数量限制
            throw new System.InvalidOperationException("Object pool has reached its maximum size.");
        }

        T newObj = GameObject.Instantiate(prefab, parent).GetComponent<T>();
        CreatedObjects++;
        poolQueue.Enqueue(newObj);
        newObj.gameObject.SetActive(false);
        return newObj;
    }


    public T Spawn(Vector3 position,Quaternion rotation)
    {
               T obj;
        if (poolQueue.Count > 0)
        {
            obj = poolQueue.Dequeue();
        }
        else
        {
            obj = CreateNewObject();
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.gameObject.SetActive(true);
        obj.OnSpawn();
        return obj;
    }


    public void Despawn(T obj)
    {
        if(obj == null) return;
        if (poolQueue.Contains(obj)) return;

        obj.gameObject.SetActive(false);
        obj.OnDespawn();
        poolQueue.Enqueue(obj);
    }


    public void ClearPool()
    {
        while (poolQueue.Count > 0)
        {
            T obj = poolQueue.Dequeue();
            GameObject.Destroy(obj.gameObject);
        }
        CreatedObjects = 0;
    }

}
