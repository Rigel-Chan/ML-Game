using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 5.0f;
    public int points;
    public bool alive = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        /*rb.velocity = new Vector2(5, rb.velocity.y);*/
       

        if (Input.GetKeyDown(KeyCode.Space) && alive)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Points"))
        {
            Debug.Log("dsadsads");
            points++;
        }

        if(collision.CompareTag("Wall"))
        {
            alive = false;
        }
    }


}
