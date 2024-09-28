using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{

    public static Player instance;


    float horizontal;
    float vertical;

    Rigidbody2D rb;

    Vector2 movement;
    private void Awake()
    {

        if(instance != null)
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {

        float speed = 4;
        Debug.Log(speed);
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

         movement = new Vector2(horizontal, vertical).normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement; 
    }
}
