using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Vector3 current;

    // Update is called once per frame
    void Update()
    {
        current = this.transform.position;
        if (current.x < 1)
        {
            current.x += 30 * Time.deltaTime * 0.3f;
            transform.position = new Vector3(current.x, current.y, current.z);
        }
    }
}
