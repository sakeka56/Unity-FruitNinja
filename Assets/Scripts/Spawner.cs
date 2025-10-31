using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnableObjects;

    public float left;
    public float right;
    public float SpawnMinSpeed;
    public float SpawnMaxSpeed;
    public float SpawnRandomMinTime;
    public float SpawnRandomMaxTime;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnableObjects.Length);
        GameObject go = Instantiate(spawnableObjects[randomIndex], transform.position, spawnableObjects[randomIndex].transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(left, right), 1, 0) * Random.Range(SpawnMinSpeed, SpawnMaxSpeed), ForceMode.Impulse);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(Random.Range(SpawnRandomMinTime,SpawnRandomMaxTime));
        }

    }
}
