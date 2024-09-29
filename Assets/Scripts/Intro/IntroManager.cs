using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private void Start()
    {
        GlobalSound.StopAllMusic();
        GlobalSound.PlayMusic("MUZYKA DO MAPY");
    }

    public int counter = 0;

    public void NextDialogue()
    {
    }
}
