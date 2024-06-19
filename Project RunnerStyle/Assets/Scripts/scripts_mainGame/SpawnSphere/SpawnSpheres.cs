using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpheres : MonoBehaviour
{
    public GameObject[] spawnObjects;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            var objectIndex = Random.Range(0, spawnObjects.Length);
            yield return new WaitForSeconds(2);
            float rand = Random.Range(-0.25f, 0.25f);
            GameObject newSphere = Instantiate(spawnObjects[objectIndex], new Vector2(rand, 11), Quaternion.identity);
            Destroy(newSphere, 11);
        }
    }
}
