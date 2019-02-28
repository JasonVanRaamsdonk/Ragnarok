using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Health : MonoBehaviour
{
    public Sprite[] sprites;
    public int Health;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Health = 3;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player health is too high
        if (Health > 3)
        {
            Health = 3;
        }

        // change player health bar depending on current health
        if (Health == 3)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (Health == 2)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (Health == 1)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (Health <= 0)
        {
            // if player health is zero - Player 1 loses 
            spriteRenderer.sprite = sprites[3];
            SceneManager.LoadScene(7);

        }

    }
}
