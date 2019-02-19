using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void start()
    {
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
    }

	void Update () {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);	
	}
}
