using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectControlType : MonoBehaviour {
    public PlayerControl thePlayer; //referencing the player character

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) //Detect mouse Input
            thePlayer.useController = false;

        if (Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0f) //if the right analog stick is moved, the game automatically switches to Controller input type
            thePlayer.useController = true;
	}
}
