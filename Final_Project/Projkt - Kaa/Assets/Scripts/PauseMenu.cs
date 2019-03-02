using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public bool isPaused;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { 
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
