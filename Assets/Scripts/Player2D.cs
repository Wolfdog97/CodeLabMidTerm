using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Controller2D))]
public class Player2D : MonoBehaviour {

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;

    float moveSpeed = 6;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;


    float gravity;
    float jumpVelocity;

    /*The different types of wall jumps the player can perform 
     * Don't forget to add values in the inspector*/
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;
    

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    public LayerMask deathLayer;



    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D _controller;

    void Start () {
        _controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        Debug.Log("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);

	}

    
	void Update ()
    {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        int wallDirectionX = (_controller.collisions.left) ? -1 : 1;

        // Adding smoothing to the change in direction
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (_controller.collisions.below) ?
            accelerationTimeGrounded : accelerationTimeAirborne);

        bool wallSliding = false;
        if((_controller.collisions.left || _controller.collisions.right) && !_controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            // Contrains the player's downward speed when sliding down the wall
            if(velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if(timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if(input.x != wallDirectionX && input.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }

        if (_controller.collisions.above || _controller.collisions.below)
        {
            velocity.y = 0;
        }


        if (Input.GetAxisRaw("Jump") != 0)
        {
            if (wallSliding)
            {
                if(wallDirectionX == input.x) //If we are trying to move in the same direction that the wall is facing
                {
                    velocity.x = -wallDirectionX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (input.x == 0) 
                {
                    velocity.x = -wallDirectionX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    velocity.x = -wallDirectionX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }
            if (_controller.collisions.below)
            {
                velocity.y = jumpVelocity;
            }
            
            Debug.Log(jumpVelocity + "I'm working");
        }
        
        velocity.y += gravity * Time.deltaTime; 
        _controller.Move (velocity * Time.deltaTime);
	}
}