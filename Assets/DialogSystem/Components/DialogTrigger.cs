using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] List<DialogProperties> Dialogs = new List<DialogProperties>();
    [SerializeField] int sceneId = -1; 
    [Button]

    private void Start()
    {
        StartDialog();
    }

    private void Update()
    {
        if(DialogSystem.instance.DialogQueue.Count == 0 && sceneId > -1)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
    public void StartDialog()
    {
        DialogSystem.instance.StopDialog();
        DialogSystem.instance.DialogQueue.AddRange(Dialogs);
        DialogSystem.instance.NextDialog();
    }
}
