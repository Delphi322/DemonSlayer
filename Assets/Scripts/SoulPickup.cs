using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulPickup : MonoBehaviour
{

    private SFXManager sfxMan;
    private void Awake()
    {
        sfxMan = FindObjectOfType<SFXManager>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<WeaponContainer>() != null) 
        {
            collision.gameObject.GetComponent<WeaponContainer>().ammo++;
            sfxMan.playerPickup.Play();
            Destroy(gameObject);
            
        }
    }
}
