using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpeed : MonoBehaviour
{

    Vector2 yote;
    Vector2 yote2;

    public void SetData(Vector2 yoting)
    {
        yote = yoting;

        yote2 = yoting * 0.02f;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = yote;
        yote -= yote2;
    }
}
