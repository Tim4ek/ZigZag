using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    public GameObject lanees;
    GameObject tempLane;
    int zPosition = 15;

	// Use this for initialization
	void Start () {
        CreateLanes();
        InvokeRepeating("CreateLanes", 5, 5);
	}
    public void CreateLanes()
    {
        int i;
        for (i=zPosition; i<zPosition+1; i++)
        {
            tempLane = Instantiate(lanees, new Vector3(0, 0, i), Quaternion.identity) as GameObject;
                        
        }

        zPosition = i+19;
        
    }
	
	
}
