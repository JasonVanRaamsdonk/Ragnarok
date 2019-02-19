using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDistuction : MonoBehaviour
{
    public GameObject sprite1;

    // Start is called before the first frame update
    void Start()
    {
        float posX = sprite1.transform.position.x;
        this.transform.position = new Vector3(posX, 4.5f, 0);
        if (sprite1.transform.position.y <= 6)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder=-2;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        float posX = sprite1.transform.position.x;
        this.transform.position = new Vector3(posX, 4.5f, 0);

        if (sprite1.transform.position.y <= 6)
        {

            this.transform.position = new Vector3(posX, 4.5f, 0);
            this.GetComponent<SpriteRenderer>().sortingOrder = -2;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "Background";

        }
        else
        {
            this.transform.position = new Vector3(posX, 4.5f, 0);
            this.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
    }
}
