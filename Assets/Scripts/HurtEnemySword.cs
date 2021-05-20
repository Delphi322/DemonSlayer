﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemySword : MonoBehaviour
{
    public int damageToGive;
    public Transform hitPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            }
        }
    }
}
