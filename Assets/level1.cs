using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{
    private void Start()
    {
        GlobalSound.StopMusic("game");
        GlobalSound.PlayMusic("AMBIENT DO GIERKI" ,true);
    }
}
