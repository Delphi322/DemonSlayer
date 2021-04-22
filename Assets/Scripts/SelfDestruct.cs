using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public float countDown;

    void Update()
    {
        if (countDown <= 0)
            Destroy(gameObject);
        else
            countDown -= Time.deltaTime;
    }
}
