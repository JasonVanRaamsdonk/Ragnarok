using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDistuction : MonoBehaviour
{
    //add the GameObject Variable (fast to call the object)
    public GameObject sprite1;

    // Start is called before the first frame update
    void Start()
    {
        //save the position of the player so you can use it 
        float posX = sprite1.transform.position.x;
        //the arrow will follow the x position, while the y is fixed
        this.transform.position = new Vector3(posX, 4.5f, 0);
        //if the player is inside the camera view the arrow is hide
        if (sprite1.transform.position.y <= 6)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder=-2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update the current position of the player 
        float posX = sprite1.transform.position.x;
        //change the position of the arrow
        this.transform.position = new Vector3(posX, 4.5f, 0);

        //check if player if on screen
        if (sprite1.transform.position.y <= 6)
        {
            //hide the arrow
            this.transform.position = new Vector3(posX, 4.5f, 0);
            this.GetComponent<SpriteRenderer>().sortingOrder = -2;

        }
        else
        {
            //show the arrow
            this.transform.position = new Vector3(posX, 4.5f, 0);
            this.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
    }
}
