using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour
{
    public int textureSize = 32;

    public bool scaleHorizontally = true;
    public bool scaleVertically = true;

    // Start is called before the first frame update
    void Start()
    {
        var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil ( Screen.width / ( textureSize * PixelPerfectCamera.scale));
        var newHeight = !scaleVertically ? 1 : Mathf.Ceil ( Screen.height / ( textureSize * PixelPerfectCamera.scale));
        // ternary operator

        // changing scale of quad based on new width & height
        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);
        //Renderer: What actaully displays the material on the quad
    }

}

/*
 * we are trying to find how many tiles will fit 
 * inside of the screens resolution. We don't want this
 * value to be lower than the screens resolution (otherwsie we'd
 * end up with possible games on either side of the screen).
 * Hence the use of ceil() maths function.
 * We do this in the Start method and not the Awake method.
 * If we performed this in the Awake method we could run into the issue 
 * were the camera hasn't set itself up yet.
 */