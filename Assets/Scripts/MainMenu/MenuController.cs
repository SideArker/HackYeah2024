using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private bool optionsOpen = false;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] CanvasGroup uiElement;
   public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void OpenCloseOptions()
    {
        if(optionsOpen)
        {
            StartCoroutine(FadeOut());
            optionsOpen = false;
        }
        else
        {
            FadeIn();
            optionsOpen = true;
        }
    }

    void FadeIn()
    {
        optionsMenu.SetActive(true);
        LeanTween.alphaCanvas(uiElement, 1f, 1f).setEase(LeanTweenType.linear);
    }
    IEnumerator FadeOut()
    {
       
        LeanTween.alphaCanvas(uiElement, 0f, 1f).setEase(LeanTweenType.linear);
        yield return new WaitForSeconds(1);
        optionsMenu.SetActive(false);

    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
