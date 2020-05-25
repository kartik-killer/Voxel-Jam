using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScriptDamage : MonoBehaviour
{
    public GameObject rifleRef;

    public PlayerControl thePlayer;

    void Start()
    {
        rifleRef = GameObject.FindWithTag("Rifle");
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (rifleRef.GetComponent<RifleScript>().currentRifleDamage == rifleRef.GetComponent<RifleScript>().rifleDamage) //this is to avoid stacking of double damage
            {
                rifleRef.GetComponent<RifleScript>().currentRifleDamage *= 2;
                gameObject.SetActive(false);
                
            }

        }
    }
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

}



