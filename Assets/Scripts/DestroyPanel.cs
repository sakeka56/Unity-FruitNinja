using UnityEngine;

public class DestroyPanel : MonoBehaviour
{


    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if(other.transform.tag == "Fruit")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("CantSlice"))
        {
            Destroy(collision.transform.root.gameObject);
        }
    }
}
