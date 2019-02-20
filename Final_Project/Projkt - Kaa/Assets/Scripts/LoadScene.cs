using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void loadScenes(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponentInChildren<Text>().color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponentInChildren<Text>().color = Color.red;
    }
}
