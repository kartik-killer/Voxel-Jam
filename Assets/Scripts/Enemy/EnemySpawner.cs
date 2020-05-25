using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy; //Prefab of the Enemy being spawned

    void Start ()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
