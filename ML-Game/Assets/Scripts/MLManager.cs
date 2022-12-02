using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLManager : MonoBehaviour
{
    public GameObject player;
    public MLWall[] walls;

    public void Reset(int score)
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            Debug.Log(score);
        }
        player.transform.localPosition = new Vector2(-4.23f, -0.04f);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<MLAgentPlayer>().points = 0;
        foreach (MLWall wall in walls)
        {
            wall.WallReset();
                
        }
    }
}
