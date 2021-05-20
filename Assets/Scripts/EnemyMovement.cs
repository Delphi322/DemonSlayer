using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator anime;

    public float moveSpeed;

    public float ClampMoveX;

    private Rigidbody2D myRigidbody;

    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();


        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

    }

    void Update()
    {
        if (moving)
        {
            anime.SetBool("Moving", true);

            timeToMoveCounter -= Time.deltaTime;

            myRigidbody.velocity = moveDirection;

            if (moveDirection.x > 0)GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;

            if (timeToMoveCounter < 0f)
            {

                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

            }
        }
        else
        {
            anime.SetBool("Moving", false);

            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }


    }
}
