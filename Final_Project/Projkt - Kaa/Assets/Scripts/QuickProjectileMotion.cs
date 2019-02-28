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
        // if gameObejct at center of cross hair - destoy porjectile
        if (transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }
        else
        {
            // move to crosshair
            // magic bullets (not OP at all)
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);

        }

    }
}
