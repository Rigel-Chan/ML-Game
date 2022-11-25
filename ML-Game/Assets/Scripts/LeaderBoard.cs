using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    int leaderboardID = 9138;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerName;



    void Start()
    {
        
    }




    public IEnumerator SubmitScoreRoutine( int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID,  (response) =>
        {
            if (response.success)
            {
                Debug.Log("score");
                done = true;
            }
            else
            {
                Debug.Log("nope score");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }



    public IEnumerator FetchTopHighscoresRoutine()
    {

        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardID,10,0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for(int i = 0; i< members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ".";
                    if(members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {

                        tempPlayerNames += members[i].player.id;

                        
                    }

                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerName.text = tempPlayerNames;
                playerScore.text = tempPlayerScores;
                Debug.Log("retrieve");

            }
            else
            {
                Debug.Log("nope retrieve");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
