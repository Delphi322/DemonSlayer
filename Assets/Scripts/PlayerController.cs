using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    public float jump;

    public bool isGrounded;

    Animator anim;

    public Vector2 lastMove;
    public float ClampMoveX;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lastMove = new Vector2(0, 0);
    }

    
    void Update()
    {
        Move();
        Jump();

        if (rb.velocity.magnitude > 0.1)
        {
            anim.SetBool("PlayerMoving", true);
            anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("ClampMoveX", Input.GetAxisRaw("Horizontal"));
            lastMove = moveInput;
        }
        else
        {
            anim.SetBool("PlayerMoving", false);
        }

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
