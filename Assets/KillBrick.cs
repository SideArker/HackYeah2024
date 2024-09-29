using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBrick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            Player.instance.KillPlayer();
        }
    }
}
