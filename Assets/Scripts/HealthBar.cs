using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite[] sprites;
    public Image[] healthImgs;
    PlayerHealth playerHealth;
    int health;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        health = playerHealth.health;

        for (int i = 0; i <= healthImgs.Length - 1; i++)
        {
            if (i < health) healthImgs[i].sprite = sprites[0];
            
            else healthImgs[i].sprite = sprites[1];
            
        }
    }
}
