using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] prefabs;
    public float delay = 2.0f;
    public bool active = true; // use to see if the Spawner is active or not.
    public Vector2 delayRange = new Vector2(1, 2);
    // using a vector2 as a range, x value is the min, and y values is max

    // Start is called before the first frame update
    void Start()
    {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
        
    }
     
    IEnumerator EnemyGenerator()    // to return an interface of Ienumerator
    {
        yield return new WaitForSeconds(delay); // we want it to execute after the delay

        if(active)
        {
            var newTransform = transform; // position were we want to spawn, refernece to the existing trasform
                                          // of our game object
            GameObjetcUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
            // Quaterion.identity: to set value of rotation to its defualt of zero
            ResetDelay();
            // reset delay after a new obstacle is instantiated
        }

        StartCoroutine(EnemyGenerator());   // restart the coroutine so it continues to ru

    }

    // reset the delay very time we spawn an new object
    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }

}
