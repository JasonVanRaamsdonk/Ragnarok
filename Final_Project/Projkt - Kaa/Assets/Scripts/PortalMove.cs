using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalMove : MonoBehaviour
{
    private Rigidbody2D portal;
    public GameObject portalPoint;
    public int Scene;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // components
        portal = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // move into frame
        transform.position = Vector2.MoveTowards(transform.position, portalPoint.transform.position, speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // check if player 1 has hit portal
        if (collider.gameObject.tag == "Player1")
        {
            Debug.Log("Player 1 Hit Protal, Switching to Scene: " + Scene);

            SceneManager.LoadScene(Scene);

        }

    }
}
