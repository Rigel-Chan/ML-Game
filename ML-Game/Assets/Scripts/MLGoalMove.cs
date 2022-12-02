using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLGoalMove : MonoBehaviour
{
    public Transform goal;

    Rigidbody2D rb;
    void Start()
    {
/*        this.gameObject.transform.position = new Vector3(goal.position.x, Random.Range(-3.5f, 3.5f));*/
        this.gameObject.transform.position = new Vector3(goal.position.x,0);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-5, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
/*            this.gameObject.transform.localPosition = new Vector3(10, Random.Range(-3.5f, 3.5f));*/
            this.gameObject.transform.localPosition = new Vector3(10, 0);
        }
    }
}
