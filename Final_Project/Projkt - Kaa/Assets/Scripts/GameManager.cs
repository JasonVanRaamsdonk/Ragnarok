using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private bool gameStarted;
    // a flag to know when the game has startedor when the game is over
    private TimeManager timeManager;
    private GameObject player;
    // create player prefab when we reset our game 
    private GameObject floor;
    private Spawner spawner;

    void Awake()
    {
        floor = GameObject.Find("Foreground");
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        timeManager = GetComponent<TimeManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // calculate where the floor needs to go on the screen
        var floorHeight = floor.transform.localScale.y;

        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
        floor.transform.position = pos;

        spawner.active = false;

        // - ResetGame() - replace with
        Time.timeScale = 0;
        // this way i dont have to keep track on whether the backgrounds are scrolling or not

        
    }

    // Update is called once per frame
    void Update()
    {
        // once game is over 'listen' for anykey then turn time back to
        // its default value of one and reset the game

        if(!gameStarted && Time.timeScale == 0)
        {
            if(Input.anyKeyDown)
            {
                timeManager.ManipulateTime(1, 1f);
                ResetGame();
            }
        }
    }

    void OnPlayerKilled()
    {
        spawner.active = false;

        var playerDestrotScript = player.GetComponent<DestroyOffscreen>();
        playerDestrotScript.DestroyCallback -= OnPlayerKilled; // shorthand to unlink 
        // when a player gets destroyed we'll get a reference to its 
        // DestrotOffscreen script and unlink

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // reset velocity of player

        timeManager.ManipulateTime(0, 5.5f);
        // when the player is donn manipulate time to become zero over a few seconds

        gameStarted = false;

     
    }

    void ResetGame()
    {
        spawner.active = true;

        player = GameObjetcUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2 + 100 , 0));
        // create an instance of the player prfab + location of placement 

        var playerDestrotScript = player.GetComponent<DestroyOffscreen>();
        playerDestrotScript.DestroyCallback += OnPlayerKilled; // shorthand to link 
        // tells the playerDestroyScript that when DestroyCallback gets called its actually going 
        // to call OnPlayerKilled inside GameManager
        // connect delegate

        gameStarted = true;
    }
}

/*
 * Reposition the floor towards the bottom of the screen no matter what the 
 * resolution is. Also a reference to the Spawner so we can turn it off when 
 * the game first begins as we only need 1 player
 */