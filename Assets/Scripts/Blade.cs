using System;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private SphereCollider SphereCollider;

    private void Awake()
    {
        SphereCollider = GetComponent<SphereCollider>();
    }

    private void OnEnable()
    {
        InputController.Instance.OnClick += HandleOnClick;


        InputController.Instance.OnClickStart += () =>
        {
            SphereCollider.enabled = true;
        };
        InputController.Instance.OnClickCancel += () =>
        {
            SphereCollider.enabled = false;
        };
           

    }
    private void OnDisable()
    {
        InputController.Instance.OnClick -= HandleOnClick;
        InputController.Instance.OnClickStart -= () =>
        {
            SphereCollider.enabled = true;
        };
        InputController.Instance.OnClickCancel -= () =>
        {
            SphereCollider.enabled = false;
        };

    }

    private void HandleOnClick(Vector2 pos)
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10f));
        transform.position = v;


    }

    private void OnTriggerEnter(Collider other)
    {
        ICanSliceObject sliceable = other.GetComponent<ICanSliceObject>();
        if (sliceable != null)
        {
            sliceable.OnSlicing();
        }
    }
}
