using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public int DeletePoint;
    public float Speed;
    private Rigidbody2D fireball;

    // Start is called before the first frame update
    void Start()
    {
        fireball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if fireball out of screen - destroy Fireball
        if (transform.position.x > DeletePoint)
        {
            Destroy(gameObject);
        }

        // add velocity
        transform.position = new Vector2(transform.position.x + Speed, transform.position.y);
    }
}
