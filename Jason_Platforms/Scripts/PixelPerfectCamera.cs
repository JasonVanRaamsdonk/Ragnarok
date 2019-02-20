using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
    public static float pixelsToUnits = 1f;
    public static float scale = 1f;

    public Vector2 nativeResolution = new Vector2(240, 160);
    // weuse this to calculate the difference in scale and scale up.

    // We want the camera to calculate the scale of the game before the game 
    // starts, hence the use of Awake() not Start()
    void Awake()
    {
        var camera = GetComponent<Camera>();

        if(camera.orthographic)
        {
            scale = Screen.height / nativeResolution.y;
            pixelsToUnits *= scale;

            camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
        }
    }

}

/*
 * this script will not automatically update if the 
 * resolution is changed when the game is running
 */
