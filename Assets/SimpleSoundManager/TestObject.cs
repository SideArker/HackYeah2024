using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    [Button]
    public void Test()
    {
        AudioSource.PlayClipAtPoint(GlobalSound.clips["ButtonBeep"], transform.position, 1f);
    }
}
