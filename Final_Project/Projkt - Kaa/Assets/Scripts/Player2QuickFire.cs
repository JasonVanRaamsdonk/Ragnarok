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
    public GameObject Target;

    // fireball projectiles
    public Rigidbody2D FireballProjectile;
    public Transform FireballOrigin;

    // Snake Tail
    public Rigidbody2D Tail;
    public Transform TailOrigin;

    // Cooldown
    public float QuickFireCooldown;
    public float Ability1Cooldown;
    public float Ability2Cooldown;
    private float NextAtivateTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NextAtivateTime)
        {

            // Controller Inputs
            if (Input.GetButton("Fire1"))
            {

                // testing input
                Debug.Log("Button B Pressed");

                // calculate next ability activate time
                NextAtivateTime = Time.time + Ability1Cooldown;

                Rigidbody2D SnakeTailClone = (Rigidbody2D)Instantiate(Tail, TailOrigin.position, TailOrigin.rotation);

            }
            else if (Input.GetButton("Fire2"))
            {
                // testing input
                Debug.Log("Button X Pressed");

                // calculate next ability activate time
                NextAtivateTime = Time.time + QuickFireCooldown;

                Debug.Log("Starting QuickFire Shots");

                // starting QuickFireAnimation
                SnakeHeadAnimator.SetBool("OnQuickFire", true);
                // start Firing Coroutine
                StartCoroutine(QuickFireAnimation());

            }
            else if (Input.GetButton("Fire3"))
            {
                // testing input
                Debug.Log("Button Y Pressed");

                // calculate next ability activate time
                NextAtivateTime = Time.time + Ability2Cooldown;

                Debug.Log("Starting Fireball shot");

                // start animation and firing
                SnakeHeadAnimator.SetBool("OnMouthFire", true);
                // start firing Corountine 
                StartCoroutine(FireballAnimation());

            }
        }

    }

    // create 4 quick fire projectiles every 0.5 of a second
    IEnumerator QuickFireAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        Rigidbody2D ProjectileClone1 = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        // send target location to projectile clone
        ProjectileClone1.GetComponent<QuickProjectileMotion>().target = Target;

        yield return new WaitForSeconds(0.5f);

        Rigidbody2D ProjectileClone2 = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        ProjectileClone2.GetComponent<QuickProjectileMotion>().target = Target;

        yield return new WaitForSeconds(0.5f);

        Rigidbody2D ProjectileClone3 = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        ProjectileClone3.GetComponent<QuickProjectileMotion>().target = Target;

        yield return new WaitForSeconds(0.5f);

        Rigidbody2D ProjectileClone4 = (Rigidbody2D) Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
        ProjectileClone4.GetComponent<QuickProjectileMotion>().target = Target;

        yield return new WaitForSeconds(0.5f);

        // turn snake animation off
        SnakeHeadAnimator.SetBool("OnQuickFire", false);

    }

    // start snake head animation
    IEnumerator FireballAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        Rigidbody2D FireballClone = (Rigidbody2D)Instantiate(FireballProjectile, FireballOrigin.position, FireballOrigin.rotation);

        yield return new WaitForSeconds(1.0f);
        SnakeHeadAnimator.SetBool("OnMouthFire", false);
    }
}
