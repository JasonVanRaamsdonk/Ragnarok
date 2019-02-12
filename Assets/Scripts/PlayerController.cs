using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint; // The player part to check if it is on the ground e.g Their feet
    public float groundCheckRadius;  // The radius around the ball
    public LayerMask groundLayer;  // The platforms 
    private bool isTouchingGround;
    private Animator playerAnimation; // Create the animation variable


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D> ();
        playerAnimation = GetComponent<Animator>(); // Get the animation component
	}
	
	// Update is called once per frame
	void Update () {
        // Going to check if any objects from the groundLayer are within the radius from the specified point
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f) // If right key is pressed then it is greater than 0
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if (movement < 0f) {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") &&  isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        // Get the velocit of the animation
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        // Get the ground position of the animation object
        playerAnimation.SetBool("OnGround", isTouchingGround);
	}
}
