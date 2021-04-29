using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesSystem : MonoBehaviour
{

    public int lives;

    public Text livesDisplay;

    Animator anim;

    private static bool playerExists;

    private bool originalPlayer;

    public Transform respawnPoint;

    bool start;


    private void Start()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else if(!originalPlayer)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        /*if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<LivesSystem>().Length > 1)
        {
            foreach (LivesSystem instance in FindObjectsOfType<LivesSystem>())
            {
                if (instance != this)
                {
                    Destroy(instance.gameObject);
                }
            }
        }*/
    }

    void Awake()
    {
        lives = 3;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        livesDisplay.text = lives.ToString();

        Death();
        if (start)
        {
            respawnPoint = FindObjectOfType<RespawnPoint>().transform;
            transform.position = respawnPoint.position;
            originalPlayer = false;
            start = false;
        }
    }

    public void Death()
    {
        if (GetComponent<PlayerHealth>().health <= 0)
        {
            GetComponent<PlayerController>().anim.SetBool("Dead", true);
            lives--;
            start = true;
            originalPlayer = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
            GetComponent<PlayerController>().anim.SetBool("Dead", false);
    }
}
