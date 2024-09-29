using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

enum enemyType
{
    Lemur,
    Bird
}


public class Enemy : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] enemyType enemyVariant;
    [Tooltip("Amount of hits enemy needs to die")]
    [SerializeField] int Health;
    [SerializeField] Material dmgMAT;
    [SerializeField] float flashDuration;
    Material originalMAT;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] Vector2 moveDirection = Vector2.left;

    bool isFacingRight = false;
    Rigidbody2D rb;

    [Header("Bird")]

    [SerializeField] float attackSpeed; // per min
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (enemyVariant == enemyType.Bird) StartCoroutine(BirdAttackTick());
        originalMAT = GetComponent<SpriteRenderer>().material;
    }


    IEnumerator BirdAttackTick()
    {
        GameObject plr = Player.instance.gameObject;

        while (true)
        {
            if (Vector2.Distance(transform.position, plr.transform.position) > 50) yield return new WaitForSeconds(1);
                Debug.Log("a");
                Instantiate(bullet, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(60 / attackSpeed);
         }
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 movement = new Vector2(moveDirection.x * speed, rb.velocity.y);

        rb.velocity = movement;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, .75f, LayerMask.GetMask("Default", "Player"));

        if (!hit) return;

        if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print(hit.transform.name);
            Player.instance.DamagePlayer();
        }

        else if (!isFacingRight && moveDirection.x <= 0f || isFacingRight && moveDirection.x >= 1f)
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
    

    IEnumerator DamageFlash()
    {
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        while (elapsedTime < flashDuration)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / flashDuration));

            print(renderer.material.GetFloat("_FlashAmount"));
            renderer.material.SetFloat("_FlashAmount", currentFlashAmount);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        GetComponent<SpriteRenderer>().material = originalMAT;

    }

    public void Damage()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.material = dmgMAT;

        StartCoroutine(DamageFlash());
              print("Damage Enemy");
        Health--;

        if(Health <= 0)
        {
            Debug.Log("Enemy dies now");
            Destroy(gameObject);
        }
    }
}
