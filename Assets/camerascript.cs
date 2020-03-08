using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera follows the player around the screen

public class camerascript : MonoBehaviour
{
     //object that the camera follows
     public Transform followPlayer;

     //modify the position
     private Vector3 moveTemp;
     public float offsetX = 3;
     public float offsetY = 3;

     // Use this for initialization
     void Start()
     {
          
     }

     // Update is called once per frame
     void Update()
     {
          // Player position.
          moveTemp = followPlayer.transform.position;

          //offset x-coordinate 3 units
          moveTemp.x += offsetX;

          //offset y-coordinate 3 units
          moveTemp.y += offsetY;

          //modify z-coordinate to be the same as the main camera z-coordinate.
          moveTemp.z = transform.position.z;

          //asing main camera position to wherever the Player is located.
          transform.position = moveTemp;
     }
}
