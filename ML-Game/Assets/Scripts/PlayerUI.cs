using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI score;
    void Update()
    {
        /*score.text = player.GetComponent<PlayerMovement>().points.ToString();*/
        score.text = player.GetComponent<MLAgentPlayer>().points.ToString();
    }

}
