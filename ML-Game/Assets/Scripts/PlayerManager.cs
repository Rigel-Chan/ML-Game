using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    public LeaderBoard lb;
    public TMP_InputField playerNameInput;


    void Start()
    {

        StartCoroutine(SetupRoutine());

        playerNameInput.text = PlayerPrefs.GetString("LocalName");

        
    }

    IEnumerator SetupRoutine()
    {

        yield return LoginRoutine();
        yield return lb.FetchTopHighscoresRoutine();

    }

    public void SetPlayerName()
    {
        PlayerPrefs.SetString("LocalName", playerNameInput.text);
        LootLockerSDKManager.SetPlayerName(playerNameInput.text, (response) =>
            {

                if (response.success)
                {
                    Debug.Log("player set");
                }
                else
                {
                    Debug.Log("player not set");
                }

            });
    }


    IEnumerator LoginRoutine ()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("nope");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

}
