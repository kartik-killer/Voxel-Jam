using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateManager : MonoBehaviour {

    public PlayerControl thePlayer;
    public float restartDelay = 5f;

    Animator anim; 
    float restartTimer;

    void Start()
    {
        anim = GetComponent<Animator>(); //Referencing Animator
    }


    void Update()
    {
        if (thePlayer.allEnemiesDead == true)
        {
            anim.SetTrigger("WinState"); //triggering our trigger 'WinState'
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel); //restarting level after 'restartDelay' seconds
            }
        }
    }
}
