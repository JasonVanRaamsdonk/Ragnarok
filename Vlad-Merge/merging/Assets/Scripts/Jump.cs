using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpspeed = 240f;
    public float forwardSpeed = 20;

    private Rigidbody2D body2d;
    private InputState inputState;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputState.standing)
        {
            if(inputState.actionButton)
            {
                body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, jumpspeed); // x and y axis
            }
        }
    }
}
