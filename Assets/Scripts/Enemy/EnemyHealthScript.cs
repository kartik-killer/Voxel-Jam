using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    public int health;
    private int currentHealth;
    public int scoreForKill;
    public PlayerControl thePlayer;
    public bool isAlive = true;
    //public ParticleSystem deathParticle;
	
	void Start ()
    {
        currentHealth = health; //initialising currentHealth value
        thePlayer = FindObjectOfType<PlayerControl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(currentHealth<=0)
        {
            ScoreManager.score += scoreForKill; /*add the specific enemy's score points to playerScore value from the PlayerHealthScript
                                                   Due to using the static variable, the score value can be accessed by just using 'ScoreManager.score'*/
            isAlive = false;
            //Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }

	}
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage; //currentHealth = currentHealth - damage;

    }
    
}
