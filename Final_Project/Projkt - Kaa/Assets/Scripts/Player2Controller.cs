using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    // movement variables
    public float CrosshairSpeed;
    private float VerticalMotion;
    private float HorizontailMotion;
    private Rigidbody2D Crosshair;

    // boundary Limits
    public float maxX, maxY;
    private float minX, minY;


    // Start is called before the first frame update
    void Start()
    {
        // play area boundary variables
        minX = -maxX;
        minY = -maxY;

        Debug.Log("Player 2 Controller - Active");

        // get crosshair rigidbody component
        Crosshair = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input of vertical and horizontal axis
        VerticalMotion = Input.GetAxis("Player 2 - Vertical");
        HorizontailMotion = Input.GetAxis("Player 2 - Horizontal");

        // give crosshair a new vector multiplied by CrosshairSpeed
        Crosshair.velocity = new Vector2(HorizontailMotion * CrosshairSpeed, VerticalMotion * CrosshairSpeed);

        // keep the cross hair in the play area boundary
        Crosshair.position = new Vector2(Mathf.Clamp(Crosshair.position.x, minX, maxX), Mathf.Clamp(Crosshair.position.y, minY, maxY));

    }

}
