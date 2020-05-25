using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour {
    public GameObject prefab;
	void Start ()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    /*void OnTriggerEnter(Collider other)           //This section of the code is to be used if we need the pick up item to respawn a few seconds after it's been picked up.
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(RespawnPickUp());
        }
    }

    IEnumerator RespawnPickUp()
    {
        yield return new WaitForSeconds(3); // Here, 3 is the number of seconds between each respawn
        Instantiate(prefab, transform.position, transform.rotation);
    }*/
}
