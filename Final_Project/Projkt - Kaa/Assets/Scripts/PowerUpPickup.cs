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
<<<<<<< HEAD
        if ( (triggered && col == null) || (triggered && !col.gameObject.activeSelf)) // if trigger; powerup landed, and platform collider properties are off
=======
        if ( triggered && !col.gameObject.activeSelf) // if trigger; powerup landed, and platform collider properties are off
>>>>>>> 0d9d945b99703cc1478c0884d49c7959168ed4c7
        {
           this.GetComponent<Rigidbody2D>().gravityScale = 0.5f; // when platform is destroyed, power up can fall
        }      	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        // if powerup touches the platform
        if (    col.gameObject.name.Equals("platforms(Clone)") 
            ||  col.gameObject.name.Equals("platforms_night(Clone)") 
            ||  col.gameObject.name.Equals("platforms_galaxy(Clone)")    )
        {
            triggered = true; // powerup landed on platform
            this.col = col; // give player.collision the platform.collision properties
            GetComponent<Rigidbody2D>().gravityScale = 0.0f; // powerup has no gravity
            GetComponent<Rigidbody2D>().velocity = col.GetComponent<Rigidbody2D>().velocity; // powerup follows platform
            GetComponent<Rigidbody2D>().position = col.GetComponent<Rigidbody2D>().position + new Vector2(0, 1); // powerup is just above platform
        }

        // when player touches potionUpgrade
        if (    (   
                        this.gameObject.name.Equals("PotionUpgrade(Clone)") 
                    ||  this.gameObject.name.Equals("HealthUpgrade_night(Clone)")
                )
        
            && col.gameObject.name.Equals("Player 1"))
        {
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");
            //get life if not 3 
            if (GameObject.Find("Player1HealthBar").GetComponent<Player1Health>().Health < 4)
            {
                GameObject.Find("Player1HealthBar").GetComponent<Player1Health>().Health++;
                this.GetComponent<CircleCollider2D>().enabled = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
            }

        }

        // when player touches jumpUpgrade
        if (    (
                        this.gameObject.name.Equals("JumpUpgrade_01(Clone)") 
                    ||  this.gameObject.name.Equals("JumpUpgrade_01_night(Clone)")
                )
                && col.gameObject.name.Equals("Player 1"))
        {
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");
            StartCoroutine(waitTime());
        }

        IEnumerator waitTime()
        {
            GameObject.Find("Player 1").GetComponent<PlayerMovement>().extraJumpsValue = 3;

            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSecondsRealtime(3);
            col.GetComponent<Renderer>().material.color = Color.blue;
            yield return new WaitForSeconds(0.5f);
            col.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            col.GetComponent<Renderer>().material.color = Color.blue;
            yield return new WaitForSeconds(0.5f);
            col.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            col.GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("Player 1").GetComponent<PlayerMovement>().extraJumpsValue = 2;
            this.gameObject.SetActive(false);
        }




    }
}