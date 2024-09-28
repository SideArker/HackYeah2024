using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] GameObject bulletDestroyParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(bulletDestroyParticle, transform.position, Quaternion.identity);
    }
}
