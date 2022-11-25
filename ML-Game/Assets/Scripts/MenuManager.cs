using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    bool mute = false;
    public AudioSource music;
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MuteMusic()
    {
        mute = !mute;
        if(mute)
        {
            music.volume = 0;
        }
        else
        {
            music.volume = 0.2f;
        }
        
    }

}
