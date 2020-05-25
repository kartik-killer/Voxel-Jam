using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemyHealth : MonoBehaviour {

    public int health;
    private int currentHealth;
    private Collider other;
    // Use this for initialization
    void Start()
    {
        currentHealth = health; //initialising currentHealth value
        other = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            /*set current collider inactive and activate a new collider which will determine the blast range of the explosion. 
            If the player is in that range, inflict damage on the player*/
            //Add explosion effect
            Destroy(gameObject);
        }

    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage; //currentHealth = currentHealth - damage;

    }
}
