using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour
{
    public bool actionButton;
    public float absVelX = 0f;
    public float absVelY = 0f;
    public bool standing;
    public float standingThreshold = 1;
    // to keep track of the threshold bteween when the velocity is slowing down
    // and when the player is actually standing

    private Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    // test whether any key has been pressed and set it to the action button
    void Update()
    {
        actionButton = Input.anyKeyDown;
    }

    void FixedUpdate()
    {
        // calculate the absolute value of the velocity.
        // The player could either be moving up or down, or left or right.
        // Those values range from positve to negative since the 00 position is
        // in the middle of the screen in Unity

        absVelX = System.Math.Abs(body2d.velocity.x);
        absVelY = System.Math.Abs(body2d.velocity.y);

        // test to see if the player is standing or not
        // if there is no movement on the y-axis, that is considered standing
        standing = absVelY <= standingThreshold;

    }
}

/*
 * This class keeps track of the absolute x and y values of the celocity of the player.
 * Note when the player is standing, and keep track of any type of input has taken place.
 */
