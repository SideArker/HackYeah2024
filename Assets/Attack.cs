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
        if (isTouched) return;
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.Damage();
            isTouched = true;
        }
    }
}
