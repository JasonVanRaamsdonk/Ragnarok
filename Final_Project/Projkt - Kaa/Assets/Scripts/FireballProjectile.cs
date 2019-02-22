using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public int DeletePoint;
    public Vector2 Speed;
    private Rigidbody2D fireball;

    // Start is called before the first frame update
    void Start()
    {
        fireball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > DeletePoint)
        {
            Destroy(gameObject);
        }

        fireball.velocity = Speed;
    }
}
