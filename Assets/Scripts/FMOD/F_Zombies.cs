using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class F_Zombies : MonoBehaviour
{
    EventInstance zombies;
    void Start()
    {
        zombies = RuntimeManager.CreateInstance("event:/Zombies/ZombieRoar");
        zombies.start();
        zombies.release();
    }

    private void OnDestroy()
    {
        zombies.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
