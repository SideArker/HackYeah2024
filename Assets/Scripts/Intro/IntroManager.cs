using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public int counter = 0;

    public void NextDialogue()
    {
        counter++;
        if(counter == 8)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
