using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameObject nextLevelUi;

    public void GoToMap()
    {
        SceneManager.LoadScene("Map");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nextLevelUi.SetActive(true);
        }
    }
}
