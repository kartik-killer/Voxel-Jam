using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator anim;
    public void PlayGame()
    {
        StartCoroutine(PlayGameRoutine());
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayGameRoutine()
    {
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DatingScene");
    }
}
