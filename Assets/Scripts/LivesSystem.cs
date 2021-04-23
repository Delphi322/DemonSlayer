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

    private void Start()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
    }

    public void Death()
    {
        if (GetComponent<PlayerHealth>().health <= 0)
        {
            Debug.Log("Aeiou");
            GetComponent<PlayerController>().anim.SetBool("Dead", true);
            lives--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
            GetComponent<PlayerController>().anim.SetBool("Dead", false);
    }
}
