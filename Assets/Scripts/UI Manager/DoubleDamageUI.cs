using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleDamageUI : MonoBehaviour {

    public GameObject thePlayer;
    Text text;
	void Start () {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (thePlayer.GetComponent<PlayerControl>().doubleDamageActive == true)
        {
            
            text.text = "Double Damage";
        }
        else
        {
            text.text = "Normal Damage";
        }
	}
}
