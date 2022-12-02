using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLWall : MonoBehaviour
{
    float origin;
    Rigidbody2D rb;
    public Transform respawnPoint;

    void Start()
    {
        origin = gameObject.transform.localPosition.x;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-5, rb.velocity.y);
    }

    public void WallReset()
    {
        gameObject.transform.localPosition = new Vector2(origin, Random.Range(-2.9f,3.4f));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("endWall"))
        {
            this.gameObject.transform.localPosition = new Vector2(respawnPoint.localPosition.x, Random.Range(-2.9f, 3.4f));
        }
      
    }

}
