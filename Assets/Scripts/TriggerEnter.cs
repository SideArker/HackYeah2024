using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    public UnityEvent ontrigger;
    public UnityEvent ontriggerout;
    public bool isIn = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ontrigger.Invoke();
            isIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isIn = false;
            ontriggerout.Invoke();
        }
    }
}
