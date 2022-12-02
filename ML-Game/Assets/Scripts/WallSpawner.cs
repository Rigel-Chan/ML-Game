using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wall;
    public bool playerDead = false;

    void Start()
    {
        StartCoroutine(SpawnWall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnWall()
    {
        while(!playerDead)
        {
            Instantiate(wall, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y+Random.Range(-2.9f,3.2f)), Quaternion.identity);

            yield return new WaitForSeconds(1.8f);

        }


        yield return null;
    }
}
