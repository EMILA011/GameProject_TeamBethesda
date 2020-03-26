using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make the enemy move in the x/y plane

public class enemy_controller : MonoBehaviour
{
     //number of units we want to move each second
     float movementSpeed = 4f;

     //controls enemy animator 
     public Animator animator;

     //
     private Rigidbody2D myRigidbody;

     //Determines whether the enemy is moving or not
     private bool moving;

     public float timeBetweenMove;
     private float timeBetweenMoveCounter;
     public float timeToMove;
     private float timeToMoveCounter;
     private Vector3 moveDirection;

     //enemy is by default facing right
     public bool faceRight = true;

     // Use this for initialization
     void Start()
     {
        myRigidbody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
        //use the Enemy_Idel animation when player is not moving.
        animator.SetFloat("speed", 0);
    }

     // Update is called once per frame
     void Update()
     {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;

                //use the Enemy_Idel animation when player is not moving.
                animator.SetFloat("speed", 0);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                float x_Axis = Random.Range(-1f, 1f) * movementSpeed;
                float y_Axis = Random.Range(-1f, 1f) * movementSpeed;

                moveDirection = new Vector3(x_Axis, y_Axis, 0f);

                //use the Enemy_Walk animation when player is moving horizontally.
                animator.SetFloat("speed", Mathf.Abs(x_Axis));

                //use the Enemy_Walk animation when player is moving vertically.
                animator.SetFloat("speed", Mathf.Abs(y_Axis));

                //if enemy is moving to the right and facing left then flip the facing direction.
                if (x_Axis > 0 && !faceRight)
                {
                    Flip();
                }
                //if enemy if moving to the left and facing right then flip the facing direction.
                else if (x_Axis < 0 && faceRight) 
                { 
                    Flip();
                }
            }
        }
     }

     //flips the x/y direction of the enemy
     void Flip()
     {
          faceRight = !faceRight;
          Vector3 enemyScale = transform.localScale;
          enemyScale.x *= -1;
          transform.localScale = enemyScale;
     }

}

     

