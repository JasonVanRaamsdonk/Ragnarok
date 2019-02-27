using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadMotion : MonoBehaviour
{
    public float MovementSpeed;
    public float MovementRadius;

    private Vector2 Center;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        Center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Center.x < -4.174 && this.gameObject.name.Equals("SnakeHead"))
        {
            Center.x += 30 * Time.deltaTime * 0.3f;
            transform.position = new Vector2(Center.x, Center.y);
        }
        if (Center.x < -6.070 && this.gameObject.name.Equals("SnakeBody"))
        {
            Center.x += 30 * Time.deltaTime * 0.3f;
            transform.position = new Vector2(Center.x, Center.y);
        }
        //make snake head move in a circular fasion
        angle += MovementSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle) * MovementRadius, Mathf.Cos(angle));
        transform.position = Center + offset;
    }
       

}
