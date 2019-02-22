using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Animator SnakeTailAnimator;

    public GameObject EndPoint;
    public GameObject tempPoint;
    public GameObject DeathPoint;

    public float dropSpeed;

    private Rigidbody2D tail;

    // Start is called before the first frame update
    void Start()
    {
        tail = GetComponent<Rigidbody2D>();
        StartCoroutine(TailWhip());
        StartCoroutine(TailDrop());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator TailWhip()
    {
        transform.position = Vector2.MoveTowards(transform.position, tempPoint.transform.position, 1);
        yield return new WaitForSeconds(0.1f);

        SnakeTailAnimator.SetBool("Preparing", true);
        yield return new WaitForSeconds(2.0f);

        SnakeTailAnimator.SetBool("Preparing", false);
    }

    IEnumerator TailDrop()
    {
        yield return new WaitForSeconds(2.3f);

        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.04f);
            transform.position = Vector2.MoveTowards(transform.position, EndPoint.transform.position, dropSpeed);
        }

        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.04f);
            transform.position = Vector2.MoveTowards(transform.position, DeathPoint.transform.position, dropSpeed);
        }

        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);

    }
}
