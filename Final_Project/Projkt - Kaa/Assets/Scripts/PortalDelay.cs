using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PortalDelay : MonoBehaviour
{
    public float PortalWait;
    public Rigidbody2D portal;
    public Transform PortalLocation;
    public GameObject PortalPoint;

    // scene to load
    public int scene;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(portalDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator portalDelay()
    {
        yield return new WaitForSeconds(PortalWait);
        Rigidbody2D Portal = (Rigidbody2D)Instantiate(portal, PortalLocation.position, PortalLocation.rotation);
        Portal.GetComponent<PortalMove>().portalPoint = PortalPoint;
        Portal.GetComponent<PortalMove>().Scene = scene;

    }

  
    
}
