using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatformDelete : MonoBehaviour
{
    public int deletePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < deletePoint)
        {
            Destroy(gameObject);
        }
    }
}
