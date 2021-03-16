using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    public float jump;

    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if(isGrounded)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * speed;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
}
