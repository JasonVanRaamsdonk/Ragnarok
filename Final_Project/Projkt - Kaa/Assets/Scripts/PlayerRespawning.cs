using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawning : MonoBehaviour
{
    private Vector3 SpawnPoint;
    private Vector3 DeathPoint;
    private Rigidbody2D player;
    public Rigidbody2D SpawnPlatform;
    public Transform PlatformSpawnPoint;
    public GameObject HealthBar;
    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        // respawning positions
        SpawnPoint = new Vector3(0.5f, 21, 0);
        DeathPoint = new Vector3(0, -15, 0);

        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player above y = 11 (respawning postition) freeze horizontal movement capabilities 
        if (this.transform.position.y > 11)
        {
            player.constraints = RigidbodyConstraints2D.FreezePositionX;

        }
        else
        {
            // if player in play area, reset player constraints and freeze rotation
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;

        }

        // if player drops out of world
        if(this.transform.position.y < -11)
        { 
            // move player to Respawn point and reset velocity 
            this.transform.position = SpawnPoint;
            player.velocity = Vector2.zero;

            // decrement the player health
            HealthBar.GetComponent<Player1Health>().Health--;

            // start respawning platform coroutine
            StartCoroutine(SpawnRespawnPlatform());

        }

    }

    // spawn sespawn platform when player drops below the world
    IEnumerator SpawnRespawnPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        Rigidbody2D RespawnPlatform = (Rigidbody2D) Instantiate(SpawnPlatform, PlatformSpawnPoint.position, PlatformSpawnPoint.rotation);

    }

    // touch snake colour change + move to respawn 
    IEnumerator TouchSnakeRespawn()
    {
        // change colours 
        yield return new WaitForSeconds(0.2f);
        col.GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(0.2f);
        col.GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(0.2f);
        col.GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(0.2f);
        col.GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(0.2f);
        
        // reset player 1 rigidbody constraints
        player.constraints = RigidbodyConstraints2D.None;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;

        // move to below the world so respawn will occur
        this.transform.position = DeathPoint;
        player.velocity = Vector2.zero;
    }

    /*

    // if player 1 collides with snake
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "")
        {
            // freeze player 1
            player.constraints = RigidbodyConstraints2D.FreezeAll;

            StartCoroutine(SpawnRespawnPlatform());
        }
    }

    */
}
