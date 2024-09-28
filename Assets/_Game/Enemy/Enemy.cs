using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    [Header("Main")]
    [Tooltip("Amount of hits enemy needs to die")]
    [SerializeField] int Health;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] Vector2 moveDirection = Vector2.left;

    bool isFacingRight = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 movement = new Vector2(moveDirection.x * speed, rb.velocity.y);

        rb.velocity = movement;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, .75f, LayerMask.GetMask("Default", "Player"));

        if (!hit) return;

        if(hit.transform.gameObject.GetComponent<Player>())
        {
            Player.instance.DamagePlayer();
        }

        if (!isFacingRight && moveDirection.x <= 0f || isFacingRight && moveDirection.x >= 1f)
        {
            moveDirection = -moveDirection;
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    private void OnDrawGizmos()
    {
        Vector2 direction = transform.TransformDirection(moveDirection)* .75f;
        Gizmos.DrawRay(transform.position, direction);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;

        Health--;

        if(Health <= 0)
        {
            Debug.Log("Enemy dies now");
            Destroy(gameObject);
        }

    }
}
