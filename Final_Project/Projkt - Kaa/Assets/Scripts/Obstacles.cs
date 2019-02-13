using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, IRecycle
{
    public Sprite[] sprites;

    public Vector2 colliderOffset = Vector2.zero;

    public void Restart()
    {
        //every time this script is restarted a random sprite will be rendered
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];

        // resizing the collider to dynamically fit each spite
        //var collider = GetComponent<BoxCollider2D>();
        //var size = renderer.bounds.size;
       // size.y += colliderOffset.y;

        //collider.size = size;
        //collider.offset = new Vector2(-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);
        // this allows for the manual override any type of offset based
        // on the type of graphics added
    }

    public void ShutDown()
    {

    }
    
}
