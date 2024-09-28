using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] GameObject bulletDestroyParticle;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletDestroyParticle, transform.position, Quaternion.identity);
        if (collision.gameObject.GetComponent<Player>())
        {
            Player.instance.DamagePlayer();
        }
        transform.GetChild(0).parent = gameObject.transform.parent;
        Destroy(gameObject);
    }
}
