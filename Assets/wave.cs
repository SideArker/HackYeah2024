using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class wave : MonoBehaviour
{
    public int direction = 1;
    private Vector3 startPos;
    [SerializeField] private float speed;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed * direction, transform.position.y, transform.position.z);
        if (math.abs(startPos.x - transform.position.x) > 36)
        {
            Destroy(gameObject);
        }
    }

}
