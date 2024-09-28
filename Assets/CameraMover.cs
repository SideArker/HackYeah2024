using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3((int)((Player.instance.transform.position.x + 12) / 24) * 24, (int)((Player.instance.transform.position.y + 6.5f) / 13) * 13, transform.position.z);
    }
}
