using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wall;
    int counter = 0;
    void Start()
    {
        StartCoroutine(SpawnWall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWall()
    {
        while(counter <10)
        {
            Instantiate(wall, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(2f);
            counter++;
        }


        yield return null;
    }
}
