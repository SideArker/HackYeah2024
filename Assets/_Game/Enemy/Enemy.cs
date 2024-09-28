using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Vector2 moveDirection = Vector2.left;

    BoxCollider2D collider;
    [SerializeField] BoxCollider2D wallCollider;

    bool isFacingRight = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 movement = new Vector2(moveDirection.x * speed, rb.velocity.y);

        rb.velocity = movement;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Enemy hit wall");

        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

    }
}
