using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagerS : MonoBehaviour
{

    public int MaxHealthS;
    public int CurrentHealthS;

    void Start()
    {
        CurrentHealthS = MaxHealthS;
    }

    void Update()
    {
        if (CurrentHealthS <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damageToGiveS)
    {
        CurrentHealthS -= damageToGiveS;
    }

    public void SetMaxHealth()
    {
        CurrentHealthS = MaxHealthS;
    }
}
