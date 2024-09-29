using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameObject nextLevelUi;
    public bool level2 = false;

    public void GoToMap()
    {
        SceneManager.LoadScene("Map");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void GoToBOss()
    {
        SceneManager.LoadScene("Dev");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!level2)
        {
            if (collision.gameObject.tag == "Player")
            {
                nextLevelUi.SetActive(true);
            }
        }
        else
        {
            GoToBOss();
        }
    }
}
