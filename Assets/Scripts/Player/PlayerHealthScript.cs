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

    private Renderer rend; //renderer reference
    private Color storedColor; //original player color reference
	
	void Start ()
    {
        currentHealth = startingHealth; //setting the initial value
        rend = GetComponent<Renderer>(); //getting the renderer and storing it in 'rend'
        storedColor = rend.material.GetColor("_Color"); //Getting the initial color of our player and storing it in 'storedColor'

        
	}

    void Update()
    {
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime; //counting down the flash counter
            if (flashCounter < 0)
            {
                rend.material.SetColor("_Color", storedColor); //restoring the color of our player from white to the original value
            }
        }
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false); //Player death
        }
        
    }
    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white); //changing the color of the material to white
    }
}
