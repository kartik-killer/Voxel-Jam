using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class F_Music : MonoBehaviour
{
    [EventRef]
    public string eventPath;
    public static EventInstance music;

    void Start()
    {
        music = RuntimeManager.CreateInstance(eventPath);
        music.start();
        music.release();
    }

    private void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
