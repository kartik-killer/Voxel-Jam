using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemyScript : MonoBehaviour
{

    private Rigidbody enemyRB;
    public float moveSpeed;

    public PlayerControl thePlayer;

    // Use this for initialization
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerControl>();

    }
    void FixedUpdate()
    {
        if (thePlayer.isActiveAndEnabled)
        {
            enemyRB.velocity = (transform.forward * moveSpeed);
        }
        else
        {
            enemyRB.velocity = new Vector3(0f, 0f, 0f); /*after the player's health drops down to zero, the enemy has no object to look to.
                                                        This was causing a glitch, hence setting velocity to 0 if the player is deactive*/
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }
}
