using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void ManipulateTime(float newTime, float duration)
    {
        if (Time.timeScale == 0)
            Time.timeScale = 0.1f;

        StartCoroutine(FadeTo(newTime, duration));
    }
        

     IEnumerator FadeTo(float value, float time)
     {
         for(float t = 0f; t < 1; t += Time.deltaTime / time)
         {
             // this way we increment this based on the difference in time from
             // one frame to another instead of arbitrarily running this entire loop

             // calculate what the timeScale should be on this current iteration
             Time.timeScale = Mathf.Lerp(Time.timeScale, value, t);

             if(Mathf.Abs(value - Time.timeScale) < .01f)
             {
                 // ensures that we don't have a scenario where time is so close to being 
                 // near zero that we dont actually reach it or that it takes a very long 
                 // time to scale down, therefor eif time is close enough to zero we'll set it to zero

                 Time.timeScale = value;
                 yield return false;
             }

             yield return null;
         }
     }
}

/*
 * setting the timeScale to zero when player dies to 
 * give the affect of pausing the game when the player 
 * is dead
 */