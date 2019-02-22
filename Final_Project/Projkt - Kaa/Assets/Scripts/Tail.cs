using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public int DeletePoint;
    public GameObject tempPoint;
    public int StopPoint;
    public float dropSpeed;
    public Vector2 Speed;
    public Vector2 ReverseSpeed;
    private Rigidbody2D tail;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        tail = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > DeletePoint)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < StopPoint)
        {
            flag = true;
        }

        if (flag == false && transform.position.y > StopPoint)
        {
            tail.velocity = Speed;
        }
        else if (flag == true)
        {
            tail.velocity = ReverseSpeed;
        }

    }

    // work in progress animation 
    /*
    IEnumerator TailMove()
    {
        yield return new WaitForSeconds(1.7f);

        if (flag == false && transform.position.y > StopPoint)
        {
            tail.velocity = Speed;
        }
        else if (flag == true)
        {
            tail.velocity = ReverseSpeed;
        }
    }

    IEnumerator TailWhip()
    {
        transform.position = Vector2.MoveTowards(transform.position, tempPoint.transform.position, dropSpeed);
        yield return new WaitForSeconds(0.5f);
    }
    */
}
