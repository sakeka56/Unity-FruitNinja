using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlicedFruit : MonoBehaviour ,IPoolable
{
    public FruitType FruitType;

    private Rigidbody[] rigidbodys;


    //储存子物体初始位置与旋转
    private Vector3[] originalPositions;
    private Quaternion[] originalRotations;

    private void Awake()
    {
        rigidbodys = GetComponentsInChildren<Rigidbody>();


        //记录子物体初始位置与旋转
        var v = transform.GetComponentsInChildren<Transform>();

        originalPositions = new Vector3[v.Length];
        originalRotations = new Quaternion[v.Length];

        for (int i = 0; i < v.Length; i++)
        {
            originalPositions[i] = v[i].localPosition;
            originalRotations[i] = v[i].localRotation;
        }
    }




    public void OnSpawn()
    {
        SetRigidbody(false);

        //重置子物体位置与旋转
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.localPosition = originalPositions[i];
            child.localRotation = originalRotations[i];
        }

    }


    public void OnDespawn()
    {
        SetRigidbody(true);
    }



    private void SetRigidbody(bool b)
    {
        foreach (var rb in rigidbodys)
        {
            rb.isKinematic = b;
        }
    }
}
