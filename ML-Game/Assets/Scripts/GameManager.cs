using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject deathWindow;


    bool mute = false;
    public AudioSource music;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.GetComponent<PlayerMovement>().alive)
        {
            deathWindow.SetActive(true);
        }
    }


    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void MuteMusic()
    {
        mute = !mute;
        if (mute)
        {
            music.volume = 0;
        }
        else
        {
            music.volume = 0.2f;
        }

    }


}
