using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float damage;

    bool debounce = false;
    float debounceTime = .3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            debounce = true;

            collision.GetComponent<Player>().DamagePlayer();

            Invoke(nameof(Cooldown), debounceTime);
        }
    }


    void Cooldown()
    {
        debounce = false;
    }

}
