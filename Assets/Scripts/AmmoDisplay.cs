using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{

    public int ammo;

    public bool isSub;

    public Text ammoDisplay;

    void Update()
    {

        /*ammoDisplay.text = ammo.ToString();
        if (Input.GetKeyDown(KeyCode.F) && !isSub && ammo > 0)
        {
            isSub = true;
            ammo--;
            isSub = false;
        }*/
    }
}
