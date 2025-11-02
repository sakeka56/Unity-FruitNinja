using UnityEngine;

public class DestroyPanel : MonoBehaviour
{


    private void OnTriggerEnter(UnityEngine.Collider other)
    {//水果进入
        if(other.transform.tag == "Fruit")
        {
            //Destroy(other.gameObject);
            ObjectPoolManager.Instance.Despawn(other.gameObject.GetComponent<IPoolable>());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {//已被切开的水果进入
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("CantSlice"))
        {
            Destroy(collision.transform.root.gameObject);
            //ObjectPoolManager.Instance.Despawn(collision.gameObject.GetComponent<IPoolable>());
        }
    }
}
