using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2 : MonoBehaviour
{
    private void Start()
    {
        GlobalSound.StopAllMusic();
        GlobalSound.PlayMusic("AMBIENT DO GIERKI", true);
    }
}
