using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{

    public float offset = 16f;
    public delegate void OnDestroy(); // event
    public event OnDestroy DestroyCallback;

    private bool offscreen;
    private float offscreenX = 0;
    private Rigidbody2D body2d;

    public int health = 100;
    public GameObject deathEffect;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            OnOutOfBounds();
        }

        if ( health <= 50)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // figure out where the offscreen X value is, center is always (0, 0)

        // offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits)/2 + offset;

        offscreenX = 11;

        //even though we foind the halfway position of the screen we're still goinmg to take 
        // extra off to account for how far off the object needs to be from the screen
    }

    // Update is called once per frame
    void Update()
    {
        var posX = transform.position.x;

        // keep track of velocity so we know which direction the object is facing
        var dirX = body2d.velocity.x;
        // is the vlaue of the x position greater than the value of the offscreen x

        if (Mathf.Abs(posX) > offscreenX)
        {
            if (dirX < 0 && posX < -offscreenX)
            {
                offscreen = true;
            }
            else if (dirX > 0 && posX > offscreenX)
            {
                offscreen = true;
            }
            else
            {
                offscreen = false;
            }

            if (offscreen)
            {
                OnOutOfBounds();
            }
        }
    }

    public void OnOutOfBounds()
    {
        offscreen = false;
        health = 100;
        
        // reseting offscreen value
        GameObjetcUtil.Destroy(gameObject);

        if (DestroyCallback != null)
        {
            // meaning a method has been set to this property
            // we attempt to calll the method thast connected to it
            DestroyCallback();
        }
    }
}

/*
 * To track when the object is off the screen
 * and when it should be deleted
 */
