using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour {
    public bool isFiring;

    public RifleBulletScript bullet;//a variable with the properties of the BulletScript
    public float bulletSpeed;

    public float timeBetweenShots; //Control the fire rate
    private float shotCounter;

    public Transform firePoint;

    public int rifleDamage;
    public int currentRifleDamage;

    public WeaponSwitchScript refNum;
	
	void Start ()
    {
        currentRifleDamage = rifleDamage;
	}
	
	
	void Update ()
    {
        if (refNum.selectedWeapon == 1) //for rifle
        {
            //UI update to rifle
            timeBetweenShots = 0.2f;
            bulletSpeed = 25;
            rifleDamage = 10;
            currentRifleDamage = rifleDamage;
        }
        if (refNum.selectedWeapon == 2) //for pistol
        {
            //UI Update to pistol
            timeBetweenShots = 1f;
            bulletSpeed = 25;
            rifleDamage = 15;
            currentRifleDamage = rifleDamage;
        }
        if (refNum.selectedWeapon == 3)// for homing missile launcher
        {
            /*Homing projectiles to be coded in the same way the enemy follows the player. 
            This can be done in the RifleBulletScript by adding if statements to check if the player has homing missile selected.*/

            //UI update to missile launcher
            timeBetweenShots = 4f;
            bulletSpeed = 25;
            rifleDamage = 150;
            currentRifleDamage = rifleDamage;
        }
        shotCounter -= Time.deltaTime; /*using this in the update function instead of under the 'if (is firing == true)' statement, 
                                         helps prevent shooting of bullets when player repeatedly presses the left Mouse Click button*/
        if (isFiring == true)
        {
           
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots; //setting our fire rate
                RifleBulletScript newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as RifleBulletScript;  /*Instantiating bullet at fire point with all 
                                                                                                                               the properties of bullet (from RifleBulletScript)*/
                newBullet.speed = bulletSpeed;
            }
        }

        
	}
}
