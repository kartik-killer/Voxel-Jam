using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public WaveManager waveRef;
    public PlayerHealthScript playerHealthRef;

    
    public GameObject gameover;

   
    public GameObject cleared;

    private bool winSoundPlayed = false;
    private bool loseSoundPlayed = false;
    
    private void Update()
    {
        if(waveRef.state == WaveManager.State.BattleOver && winSoundPlayed == false)
        {
            F_Music.music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/WinLoss/Win", this.gameObject);
            StartCoroutine(YouWin());
            winSoundPlayed = true;
        }
        if(playerHealthRef.currentHealth <= 0 && loseSoundPlayed == false)
        {
            F_Music.music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/WinLoss/Lose", this.gameObject);
            StartCoroutine(GameOver());
            loseSoundPlayed = true;
        }
    }

    IEnumerator GameOver()
    {
        gameover.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("LoseScene");
    }

    IEnumerator YouWin()
    {     
        cleared.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("WinScene");
    }
}
