using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isTouched = false;
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (isTouched) return;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        CableLemur boss = other.gameObject.GetComponent<CableLemur>();

        if (enemy)
        {
            enemy.Damage();
            isTouched = true;
        }
        else if(boss)
        {
            boss.Damage();
            isTouched = true;
        }
    }
}
