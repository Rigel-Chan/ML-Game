using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        float moveSpeed = 7f;
        transform.Translate(new Vector2(moveX, moveZ) * Time.deltaTime * moveSpeed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Points"))
        {
            Debug.Log("score");
        }
    }
}
