using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour

{

    public void loadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void doQuit()
    {
        Application.Quit();
    }
}
