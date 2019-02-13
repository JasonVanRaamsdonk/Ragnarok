using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjetcUtil
{

    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();

    // since we're not extending monobehaviour we no longer 
    // have access to the instantiate method.
    // So we use the games own static method for instantiating 
    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        // vector3 indicates the position in which we want 
        // to instantiate this object

        GameObject instance = null;

        var recycledScript = prefab.GetComponent<RecycleGameObject>();

        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            // passing in the instance of the recycled script
            instance = pool.NextObject(pos).gameObject;
        }
        else
        {
            // a way to reference this variable before we return it 
            // at the end of a method

            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
        }

        return instance;
    }

    public static void Destroy(GameObject gameObject)
    {
        // testing if the object we're about to destroy has the Recycle script attached to it

        var recycledGameObject = gameObject.GetComponent<RecycleGameObject>();

        if(recycledGameObject != null)
        {
            recycledGameObject.ShutDown();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }

        // GameObject.Destroy(gameObject);
    }

    private static ObjectPool GetObjectPool(RecycleGameObject reference)
    {
        ObjectPool pool = null;

        if(pools.ContainsKey(reference))
        {
            pool = pools[reference];
        }
        else
        {
            var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = reference;
            pools.Add(reference, pool);
        }

        return pool;
    }
}
