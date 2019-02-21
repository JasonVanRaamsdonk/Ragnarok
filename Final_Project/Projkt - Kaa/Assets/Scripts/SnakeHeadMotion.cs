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
        //make snake head move in a circular fasion
        angle += MovementSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle) * MovementRadius, Mathf.Cos(angle));
        transform.position = Center + offset;
    }
       

}
