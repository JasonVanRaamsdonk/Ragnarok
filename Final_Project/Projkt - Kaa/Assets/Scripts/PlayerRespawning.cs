using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawning : MonoBehaviour
{
    private Vector3 SpawnPoint;
    private Rigidbody2D player;
    public Rigidbody2D SpawnPlatform;
    public Transform PlatformSpawnPoint;
    public GameObject HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = new Vector3(0.5f, 21, 0);
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > 11)
        {
            player.constraints = RigidbodyConstraints2D.FreezePositionX;

        }
        else
        {
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

    IEnumerator SpawnRespawnPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        Rigidbody2D RespawnPlatform = (Rigidbody2D) Instantiate(SpawnPlatform, PlatformSpawnPoint.position, PlatformSpawnPoint.rotation);

    }
}
