using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponContainer : MonoBehaviour
{

    public int ammo;

    public bool isSub;

    public Text ammoDisplay;

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
            case 2: Axe(); break;
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
        if (Input.GetKeyDown(KeyCode.F) && !isSub && ammo > 0)
        {
            isAttacking = true;
            anim.SetBool("Mm", true);
            isSub = true;
            ammo--;
            isSub = false;
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
    public void Axe()
    {
        foreach (GameObject icon in icons)
        {
            icon.SetActive(false);

        }
        icons[1].SetActive(true);

        anim.SetBool("Mmm", false);
        if (Input.GetKeyDown(KeyCode.F) && !isSub && ammo > 0)
        {
            isAttacking = true;
            anim.SetBool("Mmm", true);
            isSub = true;
            ammo--;
            isSub = false;
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
