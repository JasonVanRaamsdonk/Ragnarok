using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
   void start()
    {
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
    }

	void Update () {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * 2);	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("platforms(Clone)"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            GetComponent<Rigidbody2D>().velocity = col.GetComponent<Rigidbody2D>().velocity; 
            GetComponent<Rigidbody2D>().position = col.GetComponent<Rigidbody2D>().position + new Vector2(0, 0.7f);
        }

        if (col.gameObject.name.Equals("Player 1"))
            { // Jason to add a recycling function
                //GameObjetcUtil.Destroy(gameObject);
                //this.gameObject.SetActive(false);
                this.GetComponent<DestroyPowerUp>().OnOutOfBounds();
            }
        
        if (col.gameObject.name.Equals("JumpUpgrade_01(Clone)"))
        {
           col.gameObject.SetActive(false); 
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("platforms(Clone)"))
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }
    }

}

