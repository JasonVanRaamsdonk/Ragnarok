using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_bullet : MonoBehaviour
{
    public int damage = 50;
    //public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.right * speed;
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        DestroyOffscreen enemy = hitInfo.GetComponent<DestroyOffscreen>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

    }

}
