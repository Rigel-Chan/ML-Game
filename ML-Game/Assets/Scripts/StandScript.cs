using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandScript : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject spawner;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            spawner.SetActive(true);
        }
    }
}
