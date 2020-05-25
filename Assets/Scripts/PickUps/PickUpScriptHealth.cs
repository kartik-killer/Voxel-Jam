using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScriptHealth : MonoBehaviour
{
    public PlayerControl thePlayer;
    
	void Start () {
        thePlayer = FindObjectOfType<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate( 0, 90 * Time.deltaTime, 0); //this is to rotate the pick up item (visual effect)
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //this is so that the item is picked up by the player only
        {
            if (thePlayer.GetComponent<PlayerHealthScript>().currentHealth < thePlayer.GetComponent<PlayerHealthScript>().startingHealth) //this is to check if the player is not at full health
            {
                thePlayer.GetComponent<PlayerHealthScript>().currentHealth = thePlayer.GetComponent<PlayerHealthScript>().startingHealth; //changing the value of currentHealth to startingHealth upon pick up
                Destroy(gameObject);
            }
            
            
        }

    }
}
