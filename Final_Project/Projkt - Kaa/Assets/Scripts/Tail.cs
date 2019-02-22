using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public int DeletePoint;
    public GameObject tempPoint;
    public int StopPoint;

    public float dropSpeed;
    public Vector2 Speed;
    public Vector2 ReverseSpeed;

    private Rigidbody2D tail;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        tail = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    
}
