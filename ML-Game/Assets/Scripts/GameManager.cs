using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject deathWindow;
    public GameObject Spawner;
    public GameObject Stand;

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


}
