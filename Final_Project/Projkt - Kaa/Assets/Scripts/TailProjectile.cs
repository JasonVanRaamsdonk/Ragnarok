using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailProjectile : MonoBehaviour
{
    // Components
    public Animator SnakeTailAnimator;
    private Rigidbody2D tail;

    // private variables
    private float t1;
    private float t2;

    // public variables
    public GameObject tempPoint;
    public float speed;
    public float time1;
    public float time2;

    // Start is called before the first frame update
    void Start()
    {
        // components
        tail = GetComponent<Rigidbody2D>();

        // timing
        t1 = Time.time + time1;
        t2 = Time.time + time2 + time1;


        // start coroutines for snake tail ability (ability 2)
        StartCoroutine(TailWhip());


    }

    // Update is called once per frame
    void Update()
    {    
        // when finished moving and out of frame - Destroy
        if (transform.position.y > 15)
        {
            Destroy(gameObject);
        }

        // wait for coroutine to finish
        if (Time.time >= t1)
        {
            // wait until the tail at lowest point
            if (Time.time >= t2)
            {
                // move up
                transform.position = new Vector2(transform.position.x, transform.position.y + speed);

            }
            else
            { 
                // move down
                transform.position = new Vector2(transform.position.x, transform.position.y - speed);

            }
        }

    }

    // move tail into frame and whip tail around
    IEnumerator TailWhip()
    {
        // move into frame
        transform.position = Vector2.MoveTowards(transform.position, tempPoint.transform.position, 1);
        yield return new WaitForSeconds(0.1f);

        // play animation
        SnakeTailAnimator.SetBool("Preparing", true);
        yield return new WaitForSeconds(2.0f);

        SnakeTailAnimator.SetBool("Preparing", false);
    }

}
