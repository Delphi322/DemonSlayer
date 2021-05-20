using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponContainer : MonoBehaviour
{
    public float speed;

    public Transform firePoint;

    public GameObject axeYeet;

    public int ammo;

    public bool isSub;

    public Text ammoDisplay;

    public int wepNumb;

    public GameObject[] icons;

    Animator anim;

    public bool isAttacking;

    public float cooldownMax, cooldown;

    private SFXManager sfxMan;

    private void Start()
    {
        foreach (GameObject icon in icons)
        {
            icon.SetActive(false);
        }

        anim = GetComponent<Animator>();
        sfxMan = FindObjectOfType<SFXManager>();
    }

    void Update()
    {
        ammoDisplay.text = ammo.ToString();
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
            isSub = true;
            ammo--;
            isSub = false;
            isAttacking = true;
            anim.SetBool("Mm", true);
            sfxMan.playerSword.Play();
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

    public void ThrowAxe()
    {
        GameObject thisYeet = Instantiate(axeYeet);
        thisYeet.transform.position = firePoint.position;
        thisYeet.GetComponent<AxeSpeed>().SetData(firePoint.forward * speed);
        if(GetComponent<PlayerController>().lastMove.x >= 0)
            thisYeet.GetComponent<SpriteRenderer>().flipX = true;
        else
            thisYeet.GetComponent<SpriteRenderer>().flipX = false;
    }

    public int damageToGiveS;
    public Transform hitPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManagerS>().HurtEnemy(damageToGiveS);
        }

    }
}
