using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallLemur : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] private float speed;
    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
        if (startPos.x - transform.position.x > 24)
        {
            Destroy(gameObject);
        }
    }
    
    
}
