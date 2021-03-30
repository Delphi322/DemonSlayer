using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulPickup : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<AmmoDisplay>() != null) 
        {
            collision.gameObject.GetComponent<AmmoDisplay>().ammo++;
            Destroy(gameObject);
        }
    }
}
