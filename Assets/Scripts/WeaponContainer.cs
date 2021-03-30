using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{

    public int wepNumb;

    public GameObject[] icons;

    Animator anim;

    public bool isAttacking;

    public float cooldownMax, cooldown;

    private void Start()
    {
        foreach (GameObject icon in icons)
        {
            icon.SetActive(false);
        }

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (wepNumb)
        {
            case 0: break;
            case 1: Sword(); break;
            case 2: break;
        }

    }
    public void Sword()
    {
        foreach (GameObject icon in icons )
        {
            icon.SetActive(false);

        }
        icons[0].SetActive(true);

        anim.SetBool("Mm", false);
        if (Input.GetKeyDown(KeyCode.F))
        {
            isAttacking = true;
            anim.SetBool("Mm", true);
            cooldown = cooldownMax;
        }
        if (isAttacking)
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;

            }
            else
            {
                isAttacking = false;
            }
        }

    }
}
