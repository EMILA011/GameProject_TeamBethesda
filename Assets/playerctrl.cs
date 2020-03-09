using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make the player move in the x/y plane

public class playerctrl : MonoBehaviour
{
     //number of units we want to move each second
     float movementSpeed = 6f;

     //controls player animator 
     public Animator animator;

     //player is by default facing right
     public bool faceRight = true;

     // Use this for initialization
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
          // holds a value for x, y and z which we will use to eventually hold the value to move in each direction. 
          //Since this is a 2D game, z will always be zero.
          //Detects whether the arrow keys are currently pressed.

          Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

          // Alters the position of the player.
          //Player will move exactly the correct amount, each frame, based on how long the frame took.

          transform.position += move * movementSpeed * Time.deltaTime;

          float horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
          float verticalMove = Input.GetAxisRaw("Vertical") * movementSpeed;

          if (Input.GetAxis("Vertical") != 0)
          {
               //use the Player_run animation when player is moving horizontally.
               animator.SetFloat("speed", Mathf.Abs(verticalMove));
          }
          else if (Input.GetAxis("Horizontal") != 0)
          {
               //use the Player_run animation when player is moving vertically.
               animator.SetFloat("speed", Mathf.Abs(horizontalMove));
          }
          else
          {
               //use the Player_idle animation when player is not moving.
               animator.SetFloat("speed", 0);
          }


          float h = Input.GetAxis("Horizontal");
          //if player is moving to the right and facing left then flip the facing direction.
          if (h > 0 && !faceRight)
               Flip();
          //if player if moving to the left and facing right then flip the facing direction.
          else if (h < 0 && faceRight)
               Flip();
     }

     //flips the x/y direction of the player
     void Flip()
     {
          faceRight = !faceRight;
          Vector3 playerScale = transform.localScale;
          playerScale.x *= -1;
          transform.localScale = playerScale;
     }

}

     

