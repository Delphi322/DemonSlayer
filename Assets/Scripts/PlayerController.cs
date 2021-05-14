using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    public float jump;

    public bool isGrounded;

    public bool isAttacking;

    public bool isDead;

    public float cooldownMax, cooldown;

    public Animator anim;

    public Vector2 lastMove;
    public float ClampMoveX;
    public Vector2 moveInput;
    Vector2 jumpVel = new Vector2(0,0);
    private SFXManager sfxMan;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lastMove = new Vector2(0, 0);
        sfxMan = FindObjectOfType<SFXManager>();
    }

    
    void Update()
    {
        if (!isAttacking) Move();
        Jump();
        Whip();
        //DontDestroyOnLoad(transform.gameObject);
        TempDeath();

       /* if (rb.velocity.magnitude > 0.1 && isGrounded)
        {
            anim.SetBool("PlayerMoving", true);
            if (Input.GetAxisRaw("Horizontal") != 0) anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
            if(Input.GetAxisRaw("Horizontal") != 0) anim.SetFloat("ClampMoveX", Input.GetAxisRaw("Horizontal"));
            lastMove = moveInput;
        }
        else
        {
            anim.SetBool("PlayerMoving", false);
        }*/

    }

    private void Whip()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isGrounded) rb.velocity = Vector2.zero;
            isAttacking = true;
            anim.SetBool("Attacking", true);
            cooldown = cooldownMax;
            sfxMan.playerAttack.Play();
        }
        if (isAttacking)
        {
            if (isGrounded) rb.velocity = Vector2.zero;
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;

            }
            else
            {
                isAttacking = false;
                anim.SetBool("Attacking", false);
            }
        }
    }

    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("PlayerMoving", false);
            if (isGrounded) rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }
        else if(isGrounded)
        {
            anim.SetBool("PlayerMoving", true);
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * speed;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);

            if (lastMove.x >= 0)
                transform.eulerAngles = new Vector2(0, 180);
            else
                transform.eulerAngles = Vector2.zero;

            lastMove.x = x;

        }
    }
    
    void Jump()
    {
        
        anim.SetBool("IsJumping", !isGrounded);
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            jumpVel = new Vector2(rb.velocity.x, jump);
            rb.velocity = jumpVel;
        }
        else if(!isGrounded)
        {
            jumpVel.y = rb.velocity.y;
            rb.velocity = jumpVel;
        }
        
    }

    void TempDeath()
    {
        if (GetComponent<PlayerHealth>().health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
