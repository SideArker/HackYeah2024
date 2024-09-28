using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public static Player instance;

    [SerializeField] float health = 4;

    public UnityEvent onPlrDeath;

    float horizontal;
    float vertical;

    Rigidbody2D rb;

    Vector2 movement;
    private void Awake()
    {

        if(instance == null)
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }


    public void DamagePlayer()
    {
        health--;

        if(health <= 0)
        {
            onPlrDeath.Invoke();
        }

        Debug.Log("Plr dmaged");
    }

    private void Update()
    {

        float speed = 4;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

         movement = new Vector2(horizontal, vertical).normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement; 
    }
}
