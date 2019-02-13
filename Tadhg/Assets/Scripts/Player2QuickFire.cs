using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2QuickFire : MonoBehaviour
{
    // animator
    public Animator SnakeHeadAnimator;

    // quick projectiles
    public Rigidbody2D projectile;
    public Transform QuickShootOrigin;

    // Cooldown
    public float QuickFireCooldown;
    private float NextAtivateTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Controller Inputs
        if (Input.GetButton("Fire1"))
        {
            // testing input
            Debug.Log("Button B Pressed");
        }
        else if (Input.GetButton("Fire2") && Time.time > NextAtivateTime)
        {
            // testing input
            Debug.Log("Button X Pressed");

            NextAtivateTime = Time.time + QuickFireCooldown;

            Debug.Log("Starting QuickFire Shots");

            // starting QuickFireAnimation
            SnakeHeadAnimator.SetBool("OnQuickFire", true);
            
            //start Firing Coroutine
            StartCoroutine(QuickFireAnimation());

        }
        else if (Input.GetButton("Fire3"))
        {
            // testing input
            Debug.Log("Button Y Pressed");
        }

    }

    // create 4 quick fire projectiles every 0.5 of a second
    IEnumerator QuickFireAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        Rigidbody2D ProjectileClone = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        yield return new WaitForSeconds(0.5f);

        ProjectileClone = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        yield return new WaitForSeconds(0.5f);

        ProjectileClone = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        yield return new WaitForSeconds(0.5f);

        ProjectileClone = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        yield return new WaitForSeconds(0.5f);
        SnakeHeadAnimator.SetBool("OnQuickFire", false);

    }

    IEnumerator MouthFireAnimation()
    {
        yield return new WaitForSeconds(1.2f);
        SnakeHeadAnimator.SetBool("OnMouthFire", false);
    }
}
