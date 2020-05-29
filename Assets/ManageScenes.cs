using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public WaveManager waveRef;
    public PlayerHealthScript playerHealthRef;

    private void Update()
    {
        if(waveRef.state == WaveManager.State.BattleOver)
        {
            SceneManager.LoadScene("WinScene");
        }
        if(playerHealthRef.currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
