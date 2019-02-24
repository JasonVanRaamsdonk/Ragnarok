using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    // animator
    public Animator SnakeTailAnimator;

    // transform points
    public GameObject EndPoint;
    public GameObject tempPoint;
    public GameObject DeathPoint;

    public float dropSpeed;

    private Rigidbody2D tail;

    // Start is called before the first frame update
    void Start()
    {
        // components
        tail = GetComponent<Rigidbody2D>();

        // start coroutines for snake tail ability (ability 2)
        StartCoroutine(TailWhip());
        StartCoroutine(TailDrop());
    }

    // Update is called once per frame
    void Update()
    {
        

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

    // make tail drop into play area - destroying any platform it touches
    IEnumerator TailDrop()
    {
        // wait for TailWhip coroutine to finish exectuting 
        yield return new WaitForSeconds(2.3f);

        // move to bottom most position
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.04f);
            transform.position = Vector2.MoveTowards(transform.position, EndPoint.transform.position, dropSpeed);
        }

        // move out of play area to be destroyed
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.04f);
            transform.position = Vector2.MoveTowards(transform.position, DeathPoint.transform.position, dropSpeed);
        }

        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);

    }
}
