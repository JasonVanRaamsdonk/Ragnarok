using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private PolygonCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D platformCollider;

    [SerializeField]
    private BoxCollider2D platformTrigger;

    // ignore the collider if player comming from other direction and not from the top
    void Start()
    {
        playerCollider = GameObject.Find("PlayerFox").GetComponent<PolygonCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
    }

    //ignore all the movements when the player hits the collider on the bottom
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "PlayerFox")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }

    //the top collider is taking in consideration
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerFox")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
         
        }
    }
}
