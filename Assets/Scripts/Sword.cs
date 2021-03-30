using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<WeaponContainer>() != null)
        {
            collision.gameObject.GetComponent<WeaponContainer>().wepNumb = 1;
            Destroy(gameObject);

        }
    }

}
