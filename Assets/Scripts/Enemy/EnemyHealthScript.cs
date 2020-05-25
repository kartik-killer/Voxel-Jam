using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    public int health;
    private int currentHealth;
    public int scoreForKill;
    public GameObject thePlayer;
	
	void Start ()
    {
        currentHealth = health; //initialising currentHealth value
        thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(currentHealth<=0)
        {
            ScoreManager.score += scoreForKill; /*add the specific enemy's score points to playerScore value from the PlayerHealthScript
                                                   Due to using the static variable, the score value can be accessed by just using 'ScoreManager.score'*/
            Destroy(gameObject);
            thePlayer.GetComponent<PlayerControl>().enemiesNumber--; /*reducing the array length value stored in enemiesNumber by 1. 
                                                                        SO that everytime an enemy is killed, its value is decreased eventually to 0 which triggers animation*/
        }

	}
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage; //currentHealth = currentHealth - damage;

    }
}
