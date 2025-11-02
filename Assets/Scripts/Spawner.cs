using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject[] spawnableObjects;

    public List<FruitType> fruitTypesToSpawn = new();

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


    /*public void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnableObjects.Length);
        GameObject go = Instantiate(spawnableObjects[randomIndex], transform.position, spawnableObjects[randomIndex].transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(left, right), 1, 0) * Random.Range(SpawnMinSpeed, SpawnMaxSpeed), ForceMode.Impulse);
    }*/

    IEnumerator Spawn()
    {
        while (true)
        {
            //SpawnObject();
            SpawnObjectWithFruitType();
            yield return new WaitForSeconds(Random.Range(SpawnRandomMinTime, SpawnRandomMaxTime));
        }

    }

    public void SpawnObjectWithFruitType()
    {
        int randomIndex = Random.Range(0, fruitTypesToSpawn.Count);
        FruitType typeToSpawn = fruitTypesToSpawn[randomIndex];
        GameObject go;
        if (typeToSpawn == FruitType.Bomb)
        {
            go = ObjectPoolManager.Instance.SpawnFruit(typeToSpawn, transform.position, Quaternion.identity);
        }
        else
        {
            go = ObjectPoolManager.Instance.SpawnFruit(typeToSpawn, transform.position, Quaternion.identity);
        }
        go.GetComponent<Rigidbody>().
            AddForce(new Vector3(Random.Range(left, right), 1, 0) * Random.Range(SpawnMinSpeed, SpawnMaxSpeed),
            ForceMode.Impulse);
        go.transform.rotation = Random.rotation;
    }
}
