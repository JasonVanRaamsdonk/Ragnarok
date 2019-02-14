using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;

    private Vector2 offset = Vector2.zero;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;

        offset = material.GetTextureOffset("_MainTex");
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += speed * Time.deltaTime;
        /*
         * the delta time represents the difference in time 
         * between one frame rendering and the next.
         */

        material.SetTextureOffset("_MainTex", offset);
    }
}
