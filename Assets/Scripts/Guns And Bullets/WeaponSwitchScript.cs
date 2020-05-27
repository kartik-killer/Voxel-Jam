using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchScript : MonoBehaviour
{
    //private Renderer rend;

    //private Color rifleColor;
    //private Color pistolColor = Color.yellow;
   // private Color missileLauncher = Color.green;

    public int selectedWeapon = 1;
    void Start()
    {
        //Fetch the Renderer from the GameObject
        //rend = GetComponent<Renderer>();
        //rifleColor = rend.material.GetColor("_Color");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Joystick1Button2)) //'X' button for rifle
        {
           // rend.material.SetColor("_Color", rifleColor);
            //selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Joystick1Button1)) //'B' button for pistol
        {
            //rend.material.SetColor("_Color", pistolColor);
            //selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)||Input.GetKeyDown(KeyCode.Joystick1Button3)) //'Y' button for missile launcher
        {
            //rend.material.SetColor("_Color", missileLauncher);
            //selectedWeapon = 3;
        }
    }
}
