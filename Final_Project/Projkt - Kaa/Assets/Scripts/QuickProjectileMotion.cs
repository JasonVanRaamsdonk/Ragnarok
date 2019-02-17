using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickProjectileMotion : MonoBehaviour
{ 
    public float speed;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    { 

    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }
        else
        {
            // magic bullets (not OP at all)
            //float step = speed * Time.time;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);

        }

    }
}
