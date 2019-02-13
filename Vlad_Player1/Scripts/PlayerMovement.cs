using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed; // speed variable used for movement
    public float fallMultiplier = 2.50f; // fall multiplier for high jumps
    public float lowMultiplier = 2.00f; // fall multiplier for low jumps
    public float jumpForce = 8.00f; // velocity when jumping 
    public LayerMask Ground; // used for setting up a raycast, put all tiles into a layer called Ground
    public float rayDistance = 1.3f; // used for setting ray length which will determine the distance from when player can jump
    public int extraJumpsValue; // how many jumps the player can have before grounding 

    private int extraJumps;  
    private bool facingRight = true; // flag if the player is facing right
    private Rigidbody2D rb2d; // shorthand for <rigidbody2d>
    private float movement = 0f; // used for storing movement 


    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is used for physics simulations
    void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(speed * movement, rb2d.velocity.y); // move left/right

        // invert the sprites image to simulate turning left and right
        if (movement > 0f && !facingRight) // if not looking right... look right
        {
            Flip();
        }
        if (movement < 0f && facingRight) //if not looking left... look left
        {
            Flip();
        }
    }

    void Update()
    {
        //jumping mechanism to simulate a more retro game like gravity
        if (rb2d.velocity.y < 0) // if the player is falling down it will increase the gravity
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump")) // if the player small jumps it has a separate gravity speed
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier - 1) * Time.deltaTime;
        }

        if (IsGrounded()) // set jumpValue when the player is grounded
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0) // jump mechanism
        {
            rb2d.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && (extraJumps == 0) && IsGrounded())
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }


        // just a fun piece of code. It changes the color of the player when the " " key pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    bool IsGrounded() // check if the player is touching the ground
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, Ground);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    void Flip() // flip the image of the player to look in a certain direction
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
