using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    public float jump;

    public bool isGrounded;

    public bool isAttacking;

    public float cooldownMax, cooldown;

    Animator anim;

    public Vector2 lastMove;
    public float ClampMoveX;
    public Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lastMove = new Vector2(0, 0);
    }

    
    void Update()
    {
        if (!isAttacking) Move();
        Jump();
        Whip();

        if (rb.velocity.magnitude > 0.1 && isGrounded)
        {
            anim.SetBool("PlayerMoving", true);
            if (Input.GetAxisRaw("Horizontal") != 0) anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
            if(Input.GetAxisRaw("Horizontal") != 0) anim.SetFloat("ClampMoveX", Input.GetAxisRaw("Horizontal"));
            lastMove = moveInput;
        }
        else
        {
            anim.SetBool("PlayerMoving", false);
        }

    }

    private void Whip()
    {
        anim.SetBool("Attacking", false);
        if (Input.GetKeyDown(KeyCode.C))
        {
            isAttacking = true;
            anim.SetBool("Attacking", true);
            cooldown = cooldownMax;
        }
        if (isAttacking)
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;

            }
            else
            {
                isAttacking = false;
            }
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
        anim.SetBool("IsJumping", !isGrounded);
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
          rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
}
