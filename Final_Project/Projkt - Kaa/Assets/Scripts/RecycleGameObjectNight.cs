using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycle2
{
    void Restart();
    void ShutDown();
}

public class RecycleGameObjectNight : MonoBehaviour
{
    private List<IRecycle2> recycleComponents;
    /*
    * a way for the recycled game object script to loop through other
    * childrens scripts on the game object its attached to and see if
    * thye implement this interface.
    */

    private void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        recycleComponents = new List<IRecycle2>();

        foreach (var component in components)
        {
            if (component is IRecycle2)
            {
                recycleComponents.Add(component as IRecycle2);
            }
            // to determine if the script is implementing the IRecycle interface
            // also cast it as the interface

            // - Debug.Log(name + " Found " + recycleComponents.Count + "Components");
            // to check how many components are found in the console Log
        }
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        // SetActive allows us to make a game object, activate it or reactivate it
        // but still have it exist in the hierarchy and in a scene.
        // You can not see it and it will not execute its scripts

        foreach (var component in recycleComponents)
        {
            component.Restart();

            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void ShutDown()
    {
        gameObject.SetActive(false);

        foreach (var component in recycleComponents)
        {
            component.ShutDown();
        }
    }
}


/*
 * When we attach this script to a game object and attempt to
 * reinstantiate a game object that already exists, we call Restart()
 * equally when we'd like to delete one we call shutdown
 * instead of using the full destroy call
 */
