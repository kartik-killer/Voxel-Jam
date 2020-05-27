using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBulletScript : MonoBehaviour {
    public float speed;
    public float bulletLifeTime;

    public GameObject rifleRef;
    private int damageInput;

	void Start ()
    {
        rifleRef = GameObject.FindWithTag("Rifle");
        if (rifleRef != null)
        {
            damageInput = rifleRef.GetComponent<RifleScript>().currentRifleDamage; //setting damage input equal to the 'currentRifleDamage' from RifleScript
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if player has homing missile launcher active (checking material of the gun), then fire missiles that follow player exactly like the enemies

        transform.Translate(Vector3.forward * speed* Time.deltaTime); //This is used to transform the position of the bullet (to fire it at speed value 'speed')

        bulletLifeTime -= Time.deltaTime;
        Debug.Log(damageInput);

        if (bulletLifeTime <= 0)
        {
            Destroy(gameObject); //This is to avoid overload of bullet clones
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy") //Any object with the tag 'Enemy' (tagged in the inspector)
        {
            other.gameObject.GetComponent<EnemyHealthScript>().HurtEnemy(damageInput); //calling the function 'HurtEnemy' and giving it input 'damageInput'
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "ExplosiveEnemy")
        {
            other.gameObject.GetComponent<ExplosiveEnemyHealth>().HurtEnemy(damageInput); //calling the function 'HurtEnemy' and giving it input 'damageInput'
            Destroy(gameObject);

        }
    }
}
