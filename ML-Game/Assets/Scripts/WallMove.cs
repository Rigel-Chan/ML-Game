using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-5, rb.velocity.y);
        StartCoroutine(WallDestroy());
    }

    IEnumerator WallDestroy()
    {

        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);

    }
}
