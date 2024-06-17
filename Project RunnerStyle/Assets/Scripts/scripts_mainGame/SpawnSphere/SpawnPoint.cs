using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject objToSpawn;

	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(objToSpawn, spawnPoint.transform.position, Quaternion.identity);
        }
	}
}
