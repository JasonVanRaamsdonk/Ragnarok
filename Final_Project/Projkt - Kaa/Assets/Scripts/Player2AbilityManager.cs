using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AbilityManager : MonoBehaviour
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
    public GameObject TempPoint;


    // Cooldowns
    private float NextAtivateTime = 0.0f;

    // cooldown between uses
    public float QuickFireCooldown;
    public float Ability1Cooldown;
    public float Ability2Cooldown;

    // animation cooldowns
    private float Cooldown1 = 5.5f;
    private float Cooldown2 = 2.6f;
    private float Cooldown3 = 1.3f;

    // transition times
    private float t1;
    private float t2;
    private float t3;

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
            if (Input.GetButton("Fire1") && Time.time > t1)
            {

                // testing input
                Debug.Log("Button B Pressed");

                // calculate next ability activate time
                NextAtivateTime = Time.time + Cooldown1;
                t1 = Time.time + Cooldown1 + Ability1Cooldown;

                // Instantiate SnakeTail and send postitions of GameObjects
                Rigidbody2D SnakeTailClone = (Rigidbody2D)Instantiate(Tail, TailOrigin.position, TailOrigin.rotation);
                SnakeTailClone.GetComponent<TailProjectile>().tempPoint = TempPoint;
                FindObjectOfType<AudioManager>().PlaySound("TailShaker");

            }
            else if (Input.GetButton("Fire2") && Time.time > t2)
            {
                // testing input
                Debug.Log("Button X Pressed");

                // calculate next ability activate time
                NextAtivateTime = Time.time + Cooldown2;
                t2 = Time.time + Cooldown2 + QuickFireCooldown;
                
                Debug.Log("Starting QuickFire Shots");

                // starting QuickFireAnimation
                SnakeHeadAnimator.SetBool("OnQuickFire", true);

                // play the QuickShot Sound
                FindObjectOfType<AudioManager>().PlaySound("QuickShot");

                // start Firing Coroutine
                StartCoroutine(QuickFireAnimation());

            }
            else if (Input.GetButton("Fire3") && Time.time > t3)
            {
                // testing input
                Debug.Log("Button Y Pressed");

                // calculate next ability activate time
                NextAtivateTime = Time.time + Cooldown3;
                t3 = Time.time + Cooldown3 + Ability2Cooldown;

                Debug.Log("Starting Fireball shot");

                // start animation and firing
                SnakeHeadAnimator.SetBool("OnMouthFire", true);

                // start firing Corountine 
                StartCoroutine(FireballAnimation());

                // Play the FireBall sound
                FindObjectOfType<AudioManager>().PlaySound("FireBall");
            }
        }

    }

    // create 4 quick fire projectiles every 0.5 of a second
    IEnumerator QuickFireAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        // Instantiate QuickProjectile Clone and send target location to projectile clone
        Rigidbody2D ProjectileClone1 = (Rigidbody2D)Instantiate(projectile, QuickShootOrigin.position, QuickShootOrigin.rotation);
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

        // turn snake animation off
        SnakeHeadAnimator.SetBool("OnQuickFire", false);

    }

    // start snake head animation
    IEnumerator FireballAnimation()
    {
        // instantiate Fireball 
        yield return new WaitForSeconds(0.4f);
        Rigidbody2D FireballClone = (Rigidbody2D)Instantiate(FireballProjectile, FireballOrigin.position, FireballOrigin.rotation);

        // turn off animation
        yield return new WaitForSeconds(1.0f);
        SnakeHeadAnimator.SetBool("OnMouthFire", false);
    }
}
