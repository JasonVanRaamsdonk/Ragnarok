using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
// object pool will be attached to a game object so will leave it extending monobehaviour
{

    public RecycleGameObject prefab;

    // a list is similar to an array, but you can add or remove items dynamically
    private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();


    // make method private so other methods can't ask it to inadvertantly create 
    // objects on the fly
    private RecycleGameObject CreateInstance(Vector3 pos)
    // vector3 to indicate the positon where we would like to create the object
    {
        var clone = GameObject.Instantiate(prefab);
        clone.transform.position = pos;
        clone.transform.parent = transform;
        // we want to ensure that any prefab instance we create is nested
        // into the object pool game object in the hierarchy view 

        poolInstances.Add(clone);

        return clone;
    }

    public RecycleGameObject NextObject(Vector3 pos)
    {
        RecycleGameObject instance = null;

        foreach(var go in poolInstances)
        // go through each game object and see if its set to false
        {
            if (go.gameObject.activeSelf != true)
                // since 'go' is autmoaticllay typed to a recycled game object
                // we need a reference of the object its attached to
            {
                instance = go;
                instance.transform.position = pos;
            }
        }

        if(instance == null)
            instance = CreateInstance(pos);
        

        instance.Restart();

        return instance;
    }
}
