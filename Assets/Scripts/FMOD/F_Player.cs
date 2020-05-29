using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class F_Player : MonoBehaviour
{
    public static EventInstance gunShot;

    private void Start()
    {
        gunShot = RuntimeManager.CreateInstance("event:/Weapons/MachineGunFullAuto");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunShot.start();
            gunShot.setParameterByName("FullAuto", 0);

        }
        if (Input.GetMouseButtonUp(0))
        {
            gunShot.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }

    private void OnDestroy()
    {
        
    }
}
