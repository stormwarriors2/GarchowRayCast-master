using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization



    public float jumpTime = 0.75f;
    public float jumpHeight = 3;
    bool isGrounded = false;
    public float acceleration = 10;
    public float sprint = 25;
    private float gravity;
    float jumpImpulse;
    public static float life = 0;
    Vector3 velocity = new Vector3();
    PawnAABB pawn;

	void Start () {
        pawn = GetComponent<PawnAABB>();
        DeriveJumpValues();
        life = 5;


    }

    void DeriveJumpValues()
    {
        gravity = (jumpHeight * 2) / (jumpTime * jumpTime);
        jumpImpulse = gravity * jumpTime;

    }
	
	// Update is called once per frame
	void Update ()
    {
        HandleInput();


        // velocity.y += axisY * 12 * Time.deltaTime;

        // do move

        PawnAABB.CollisionResults results = pawn.Move(velocity * Time.deltaTime);
        if (results.hitTop || results.hitBottom) velocity.y = 0;
        if (results.hitLeft || results.hitRight) velocity.x = 0;
        
   //     PawnAABB.CollisionResults lavaresults = 

        isGrounded = results.hitBottom;
        transform.position += results.distance;

        
        //one unique object to interact with
        //


    }
    /// <summary>
    /// Handle Input
    /// Handles players input of jumping(vertical) and horizontal movement
    /// </summary>
    private void HandleInput()
    {
        //movement

        //gravity
        velocity.y -= gravity * Time.deltaTime;
        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpImpulse;
        }
        //crouch 

        //sprint

        //sideways movement // TODO 

        float axisH = Input.GetAxisRaw("Horizontal");

        if (axisH == 0)
        {
            Decelerate(acceleration);
        }
        else
        {
            AccelerateX(axisH * acceleration);
        }
        if (Input.GetButtonUp("Sprint"))
        {
            AccelerateX(axisH * acceleration * sprint);
        }

    
    }
    /// <summary>
    /// Deceleration
    /// Player is decelerating the speed so slides and stops at a certain point
    /// setting the velocity to 0
    /// </summary>
    /// <param name="amount"> float </param>
    private void Decelerate(float amount)
    {
        //slow down player

        if (velocity.x > 0)//moving to the right
        {
            AccelerateX(-amount);
            if (velocity.x < 0) velocity.x = 0;
        }
        else if (velocity.x < 0) //moving to the left
        {
            AccelerateX(amount);
            if (velocity.x > 0) velocity.x = 0;
        }
    }

    private void AccelerateX(float amount)
    {
        velocity.x += amount * Time.deltaTime;
    }
}
