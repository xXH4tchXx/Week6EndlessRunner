using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public List<GameObject> Prefabs;
    public float MaxSpawnDelay = 2f; //This should be the amount of time delay in seconds 
    public bool MoveRight;

    // Use this for initialization
    void Start ()
    {
        if (Prefabs.Count > 0)
        {
            StartCoroutine(SpawnObjects());
        }
        else
        {
            Debug.LogWarning("There Are No Objects To Spawn");
        }
	}

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, MaxSpawnDelay));

        Instantiate(Prefabs[Random.Range(0, Prefabs.Count)], transform.position, Quaternion.identity).GetComponent<Obstacale>()._moveRight = MoveRight;
        StartCoroutine(SpawnObjects());
    }
}
