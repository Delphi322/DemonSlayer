using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    /* [SerializeField]
     GameObject player;

     [SerializeField]
     float timeOffSet;

     [SerializeField]
     Vector2 posOffSet;

     [SerializeField]
     float leftLimit;
     [SerializeField]
     float rightLimit;
     [SerializeField]
     float bottomLimit;
     [SerializeField]
     float topLimit;

     void Update()
     {
         Vector3 startPos = transform.position;

         Vector3 endPos = player.transform.position;

         endPos.x += posOffSet.x;
         endPos.y += posOffSet.y;
         endPos.z = -10;

         transform.position = Vector3.Lerp(startPos, endPos, timeOffSet * Time.deltaTime);


         transform.position = new Vector3
         (
          Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
          Mathf.Clamp(transform.position.x, topLimit, bottomLimit),
          transform.position.z
         );

     }


     private void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
         Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
         Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
         Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
     }
    */
}
