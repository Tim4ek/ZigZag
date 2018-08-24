using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownObject : MonoBehaviour {

    public GameObject objects;
    public float minSpawnTime, maxSpownTime;
    public bool spawnMovingObjects = true;

	// Use this for initialization
	void Start () {

        SpawnMovingObjects();
        

    }
    void SpawnMovingObjects()
    {
        Instantiate(objects, transform.position,Quaternion.identity);

        Invoke("SpawnMovingObjects", Random.Range(minSpawnTime, maxSpownTime));
    }
	
	
}
