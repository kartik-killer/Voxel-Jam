using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //Including UI
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public Slider healthSlider;

    public float flashLength;
    private float flashCounter;

    private Light pointLight;
    public GameObject pointLightObject;//renderer reference
    private Color storedColor; //original player color reference
    public Color damageColor;


	
	void Awake ()
    {
        currentHealth = startingHealth; //setting the initial value
        pointLight = pointLightObject.GetComponentInChildren<Light>(); //getting the renderer and storing it in 'rend'
        storedColor = pointLight.color; //Getting the initial color of our player and storing it in 'storedColor'
	}

    void Update()
    {
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime; //counting down the flash counter
            if (flashCounter < 0)
            {
                pointLight.color = storedColor; //restoring the color of our player from white to the original value
            }
        }
        healthSlider.value = currentHealth/2;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false); //Player death
        }
        
    }
    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        
        flashCounter = flashLength;

        pointLight.color = damageColor ; //changing the color of the material to white
    }
}
