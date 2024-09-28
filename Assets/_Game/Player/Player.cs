using System;
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

    private PlayerMovement _playerMovement;

    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject attackObject;

    private bool isAttacking = false;
    [SerializeField] private float attackDelay = 0.5f;

    float horizontal;
    float vertical;

    // Rigidbody2D rb;

    Vector2 movement;
    private void Awake()
    {

        if(instance == null)
        instance = this;

        // rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void DamagePlayer()
    {
        health--;

        // _playerMovement.OnJumpInput();
        
        if(health <= 0)
        {
            onPlrDeath.Invoke();
        }

        Debug.Log("Plr dmaged");
    }

    public void Attack()
    {
        if(isAttacking == false)
            StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        var temp = Instantiate(attackObject);
        temp.transform.position = attackPoint.position;
        yield return new WaitForSecondsRealtime(attackDelay);
        isAttacking = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }


    // private void Update()
    // {
    //
    //
    //
    //     float speed = 4;
    //     // horizontal = Input.GetAxisRaw("Horizontal");
    //     // vertical = Input.GetAxisRaw("Vertical");
    //
    //      movement = new Vector2(horizontal, vertical).normalized * speed;
    // }

    // private void FixedUpdate()
    // {
    //     rb.velocity = movement; 
    // }
}
