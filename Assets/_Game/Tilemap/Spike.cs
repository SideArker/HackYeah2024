using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spike : MonoBehaviour
{

    bool debounce = false;
    float debounceTime = .3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() && !debounce)
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
