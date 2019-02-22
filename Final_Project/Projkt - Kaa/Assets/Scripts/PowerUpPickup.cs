using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
   bool triggered = false; // trigger for when powerup lands on platform
   Collider2D col;

   void start()
    {
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
    }

	void Update () {    
        // onTriggerExit() workaround since it doesnt recognise when an object is destroyed
        if ( triggered && !col.gameObject.activeSelf) // if trigger; powerup landed, and platform collider properties are off
        {
           this.GetComponent<Rigidbody2D>().gravityScale = 0.5f; // when platform is destroyed, power up can fall
        }      	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        // if powerup touches the platform
        if (col.gameObject.name.Equals("platforms(Clone)"))
        {
            triggered = true; // powerup landed on platform
            this.col = col; // give player.collision the platform.collision properties
            GetComponent<Rigidbody2D>().gravityScale = 0.0f; // powerup has no gravity
            GetComponent<Rigidbody2D>().velocity = col.GetComponent<Rigidbody2D>().velocity; // powerup follows platform
            GetComponent<Rigidbody2D>().position = col.GetComponent<Rigidbody2D>().position + new Vector2(0, 1); // powerup is just above platform
        }

        // deactivate powerup when touching player1
        if (col.gameObject.name.Equals("Player 1"))
            {
                this.gameObject.SetActive(false);
            }
        

        // power up integration in the code below please!!!!!!!!!!!11 ////////////////////////////////////////////

        // when player touches jumpUpgrade
        if (this.gameObject.name.Equals("PotionUpgrade(Clone)") && col.gameObject.name.Equals("Player 1"))
        {
            // do something 
            col.GetComponent<Renderer>().material.color = Color.red;
        }

        // when player touches jumpUpgrade
        if (this.gameObject.name.Equals("JumpUpgrade_01(Clone)") && col.gameObject.name.Equals("Player 1"))
        {
            // do something
            col.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}