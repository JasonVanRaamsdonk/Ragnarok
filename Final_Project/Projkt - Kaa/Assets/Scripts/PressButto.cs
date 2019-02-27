using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButto : MonoBehaviour
{
    public GameObject sprite1;

    void Start()
    {
        //save the position of the player so you can use it 
        float posX = sprite1.transform.position.x;
        //the arrow will follow the x position, while the y is fixed
        this.transform.position = new Vector3(posX, 4.5f, 0);
        //if the player is inside the camera view the arrow is hide
        if (sprite1.transform.position.x <= -16 && sprite1.transform.position.x>-10)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = -2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update the current position of the player 
        float posX = sprite1.transform.position.x;
        //change the position of the arrow
        this.transform.position = new Vector3(posX+1, -3, 4);

        //check if player if on screen
        if (sprite1.transform.position.x <= -50 || sprite1.transform.position.x > -10)
        {
            //hide the arrow
            this.GetComponent<SpriteRenderer>().sortingOrder = -4;
        }
        else
        {
            this.transform.position = new Vector3(posX + 1, -3, 0);
            //show the arrow
            StartCoroutine(waitTime());
        }

    }
    IEnumerator waitTime()
    {
        do
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 4;
            yield return new WaitForSecondsRealtime(0.15f);
            this.GetComponent<SpriteRenderer>().sortingOrder = -2;
            yield return new WaitForSecondsRealtime(0.15f);
        } while(sprite1.transform.position.x>-50 && sprite1.transform.position.x < -10);
    }
}
